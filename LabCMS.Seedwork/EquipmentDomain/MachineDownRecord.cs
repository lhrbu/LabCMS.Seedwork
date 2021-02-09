using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json;
using System.Text.Json.Serialization;
using LabCMS.Seedwork.Converters;
using LabCMS.Seedwork.PersonnelDomain;

namespace LabCMS.Seedwork.EquipmentDomain
{
    public record MachineDownRecord
    {
        [Key]
        public int Id {get;set;}

        [ForeignKey(nameof(Applicant))]
        public string UserId {get;set;}=null!;
        public Person? Applicant {get;set;}
        public string EquipmentNo {get;set;}=null!;
        [JsonConverter(typeof(JsonConverters.DateTimeOffsetJsonConverter))]
        public DateTimeOffset MachineDownDate {get;set;} = DateTimeOffset.Now;
        [JsonConverter(typeof(JsonConverters.NullableDateTimeOffsetJsonConverter))]
        public DateTimeOffset? MachineRepairedDate {get;set;}
        public string Comment {get;set;}=null!;
    }
}