﻿using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Netcool.Core.Entities
{
    public abstract class AuditEntity : AuditEntity<int>
    {

    }

    public abstract class AuditEntity<TPrimaryKey> : CreateAuditEntity<TPrimaryKey>, IAudit
    {
        public DateTime? UpdateTime { get; set; }

        public int? UpdateUserId { get; set; }
    }
}
