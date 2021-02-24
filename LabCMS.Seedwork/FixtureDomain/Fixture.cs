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
        public string ProjectShortName {get;set;} = null!;

        [ForeignKey(nameof(TestField))]
        public string TestFieldName { get; set; } = null!;
        public TestField? TestField {get;set;}
        public string SetIndex {get;set;} = null!;
        [NotMapped]
        public string Description => $"{ProjectShortName}-{TestFieldName.First()}-{SetIndex}";
        public string StorageInformation {get;set;} = null!;
        public bool InFixtureRoom {get;set;} = true;
        public int ShelfNo {get;set;}
        public int FloorNo {get;set;}
        [NotMapped]
        public string LocationNo=>$"{ShelfNo}-{FloorNo}";
        public string? AssetNo {get;set;}
        public string? Note {get;set;}
    }
}