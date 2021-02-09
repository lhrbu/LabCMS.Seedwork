using System;
using System.ComponentModel.DataAnnotations;

namespace LabCMS.Seedwork
{
    public record Version
    {
        [Key]
        public string No {get;init;} = null!;
        public string Comment {get;init;} = null!;
    }
}