using System;
using System.ComponentModel.DataAnnotations;

namespace LabCMS.Seedwork.PersonnelDomain
{
    public record Person
    {
        [Key]
        public string UserId {get;set;} = null!;
        public string Email {get;set;} =null!;
        public string PasswordMD5MD5 { get; set; } = null!;
    }
}