using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LabCMS.Seedwork.PersonnelDomain;
using LabCMS.Seedwork.TestFieldDomain;

namespace LabCMS.Seedwork.FixtureDomain
{
    public class Role
    {
        [Key]
        [ForeignKey(nameof(Person))]
        public string UserId { get; init; } = null!;
        public Person? Person {get;set;}
        public int AuthLevel { get; set; }
        
        [ForeignKey(nameof(ResponseTestField))]
        public string? ResponseTestFieldName {get;set;}
        public TestField? ResponseTestField {get;set;}
    }
}