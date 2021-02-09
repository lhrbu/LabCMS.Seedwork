using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using LabCMS.Seedwork.ProjectDomain;
using LabCMS.Seedwork.Converters;

namespace LabCMS.Seedwork.EquipmentDomain
{
    public class UsageRecord
    {
        [Key]
        public int Id { get; set; }
        public string User { get; set; } = null!;
        public string TestNo { get; set; } = null!;

        [ForeignKey(nameof(EquipmentHourlyRate))]
        public string EquipmentNo { get; set; } =null!;
        public EquipmentHourlyRate? EquipmentHourlyRate { get; set; }
        public string? TestType { get; set; }

        [ForeignKey(nameof(Project))]
        public string ProjectNo { get; set; } = null!;
        public Project? Project { get; set; }

        [JsonConverter(typeof(JsonConverters.DateTimeOffsetJsonConverter))]
        public DateTimeOffset StartTime { get; set; }
        [JsonConverter(typeof(JsonConverters.DateTimeOffsetJsonConverter))]
        public DateTimeOffset EndTime { get; set; }

        [JsonIgnore]
        [NotMapped]
        public double Duration => (EndTime-StartTime).TotalHours;
    }
}