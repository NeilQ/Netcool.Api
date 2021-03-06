﻿using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Netcool.Core.Entities;
using Netcool.Core.Repositories;
using Netcool.Core.Services.Dto;

namespace Netcool.Core.Services
{
    public abstract class CrudService<TEntity, TEntityDto>
        : CrudService<TEntity, TEntityDto, int>
        where TEntity : class, IEntity<int>
        where TEntityDto : IEntityDto<int>
    {
        protected CrudService(IRepository<TEntity, int> repository, IServiceAggregator serviceAggregator)
            : base(repository, serviceAggregator)
        {
        }
    }

    public abstract class CrudService<TEntity, TEntityDto, TPrimaryKey>
        : CrudService<TEntity, TEntityDto, TPrimaryKey, IPageRequest>
        where TEntity : class, IEntity<TPrimaryKey>
        where TEntityDto : IEntityDto<TPrimaryKey>
    {
        protected CrudService(IRepository<TEntity, TPrimaryKey> repository, IServiceAggregator serviceAggregator)
            : base(repository, serviceAggregator)
        {
        }
    }

    public abstract class CrudService<TEntity, TEntityDto, TPrimaryKey, TGetAllInput>
        : CrudService<TEntity, TEntityDto, TPrimaryKey, TGetAllInput, TEntityDto, TEntityDto>
        where TEntity : class, IEntity<TPrimaryKey>
        where TEntityDto : IEntityDto<TPrimaryKey>
    {
        protected CrudService(IRepository<TEntity, TPrimaryKey> repository, IServiceAggregator serviceAggregator)
            : base(repository, serviceAggregator)
        {
        }
    }

    public abstract class CrudService<TEntity, TEntityDto, TPrimaryKey, TGetAllInput, TCreateInput>
        : CrudService<TEntity, TEntityDto, TPrimaryKey, TGetAllInput, TCreateInput, TCreateInput>
        where TEntity : class, IEntity<TPrimaryKey>
        where TEntityDto : IEntityDto<TPrimaryKey>
        where TCreateInput : IEntityDto<TPrimaryKey>
    {
        protected CrudService(IRepository<TEntity, TPrimaryKey> repository, IServiceAggregator serviceAggregator)
            : base(repository, serviceAggregator)
        {
        }
    }

    public abstract class CrudService<TEntity, TEntityDto, TPrimaryKey, TGetAllInput, TCreateInput, TUpdateInput>
        : CrudService<TEntity, TEntityDto, TPrimaryKey, TGetAllInput, TCreateInput, TUpdateInput,
            EntityDto<TPrimaryKey>>
        where TEntity : class, IEntity<TPrimaryKey>
        where TEntityDto : IEntityDto<TPrimaryKey>
        where TUpdateInput : IEntityDto<TPrimaryKey>
    {
        protected CrudService(IRepository<TEntity, TPrimaryKey> repository, IServiceAggregator serviceAggregator)
            : base(repository, serviceAggregator)
        {
        }
    }

    public abstract class CrudService<TEntity, TEntityDto, TPrimaryKey, TGetAllInput, TCreateInput, TUpdateInput,
            TGetInput>
        : CrudService<TEntity, TEntityDto, TPrimaryKey, TGetAllInput, TCreateInput, TUpdateInput, TGetInput,
            EntityDto<TPrimaryKey>>
        where TEntity : class, IEntity<TPrimaryKey>
        where TEntityDto : IEntityDto<TPrimaryKey>
        where TUpdateInput : IEntityDto<TPrimaryKey>
        where TGetInput : IEntityDto<TPrimaryKey>
    {
        protected CrudService(IRepository<TEntity, TPrimaryKey> repository, IServiceAggregator serviceAggregator)
            : base(repository, serviceAggregator)
        {
        }
    }

    public abstract class CrudService<TEntity, TEntityDto, TPrimaryKey, TGetAllInput, TCreateInput, TUpdateInput,
            TGetInput, TDeleteInput>
        : CrudServiceBase<TEntity, TEntityDto, TPrimaryKey, TGetAllInput, TCreateInput, TUpdateInput>,
            ICrudService<TEntityDto, TPrimaryKey, TGetAllInput, TCreateInput, TUpdateInput, TGetInput, TDeleteInput>
        where TEntity : class, IEntity<TPrimaryKey>
        where TEntityDto : IEntityDto<TPrimaryKey>
        where TUpdateInput : IEntityDto<TPrimaryKey>
        where TGetInput : IEntityDto<TPrimaryKey>
        where TDeleteInput : IEntityDto<TPrimaryKey>
    {
        protected CrudService(IRepository<TEntity, TPrimaryKey> repository, IServiceAggregator serviceAggregator)
            : base(repository, serviceAggregator)
        {
        }

        public virtual TEntityDto Get(TPrimaryKey id)
        {
            CheckGetPermission();

            var entity = GetEntityById(id);
            return MapToEntityDto(entity);
        }

        public virtual PagedResultDto<TEntityDto> GetAll(TGetAllInput input)
        {
            CheckGetPermission();

            var query = CreateFilteredQuery(input);

            var totalCount = 0;
            if ((input is IPageRequest request) && request.Page > 0 && request.Size > 0)
            {
                totalCount = query.AsNoTracking().Count();
            }

            query = ApplySort(query, input);
            query = ApplyPaging(query, input);

            var entities = query.AsNoTracking().ToList();

            return new PagedResultDto<TEntityDto>(
                totalCount,
                entities.Select(MapToEntityDto).ToList()
            );
        }

        public virtual void BeforeCreate(TEntity entity)
        {
            CheckCreatePermission();
        }

        public virtual TEntityDto Create(TCreateInput input)
        {
            var entity = MapToEntity(input);
            BeforeCreate(entity);

            Repository.Insert(entity);
            UnitOfWork.SaveChanges();

            return MapToEntityDto(entity);
        }

        public virtual void BeforeUpdate(TUpdateInput input, TEntity originEntity)
        {
            CheckUpdatePermission();
        }

        public virtual TEntityDto Update(TUpdateInput input)
        {
            var entity = GetEntityById(input.Id);

            BeforeUpdate(input, entity);
            MapToEntity(input, entity);
            UnitOfWork.SaveChanges();

            return MapToEntityDto(entity);
        }

        public virtual void Delete(TPrimaryKey id)
        {
            BeforeDelete(new[] {id});
            Repository.Delete(id);
            UnitOfWork.SaveChanges();
        }

        public virtual void Delete(IEnumerable<TPrimaryKey> ids)
        {
            if (ids == null || !ids.Any()) return;
            BeforeDelete(ids);
            Repository.Delete(t => ids.Contains(t.Id));
            UnitOfWork.SaveChanges();
        }

        protected virtual TEntity GetEntityById(TPrimaryKey id)
        {
            return Repository.Get(id);
        }

        protected virtual void BeforeDelete(IEnumerable<TPrimaryKey> ids)
        {
            CheckDeletePermission();
        }
    }
}