using System.ComponentModel.DataAnnotations;

namespace LabCMS.Seedwork.ProjectDomain
{
    public record Project
    {
        [Key]
        public string No { get; set; } = null!;
        public string Name { get; set; } = null!;
        public string NameInFIN { get; set; } = null!;
    }
}