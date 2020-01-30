﻿using System.ComponentModel.DataAnnotations;

namespace Netcool.Api.Domain.Users
{
    public class ResetPasswordInput
    {
        [MaxLength(32)]
        [MinLength(5)]
        [Required(AllowEmptyStrings = false)]
        public string New { get; set; }
        
        [MaxLength(32)]
        [MinLength(5)]
        [Required(AllowEmptyStrings = false)]
        public string Confirm { get; set; }
    }
}