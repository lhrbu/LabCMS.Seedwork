using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using LabCMS.Seedwork.FixtureDomain;

namespace LabCMS.Seedwork.TestFieldDomain
{
    public record TestField
    {
        [Key]
        public string Name {get;set;} = null!;
        public List<Role>? Roles { get; set; }
        public List<Fixture>? Fixtures { get; set; }

    }
}