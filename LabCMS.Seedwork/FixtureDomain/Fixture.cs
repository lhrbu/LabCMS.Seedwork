using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System;
using LabCMS.Seedwork.ProjectDomain;
using LabCMS.Seedwork.TestFieldDomain;

namespace LabCMS.Seedwork.FixtureDomain
{
    public record Fixture
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int No {get;set;}

        [ForeignKey(nameof(Project))]
        public string ProjectNo {get;set;} = null!;

        public Project? Project {get;set;}

        [ForeignKey(nameof(TestField))]
        public string TestFieldName { get; set; } = null!;
        public TestField? TestField {get;set;}

        public string SetIndex {get;set;} = null!;
        public string Description => Project is not null?
            $"{Project?.Name}-{TestField?.Name.First()}-{SetIndex}":
            throw new InvalidOperationException("Not load project before get description!");

        public string StorageInformation {get;set;} = null!;
        public int ShelfNo {get;set;}
        public int FloorNo {get;set;}
        [NotMapped]
        public string LocationNo=>$"{ShelfNo}-{FloorNo}";
        public string? AssetNo {get;set;}
        public string? Note {get;set;}
    }
}