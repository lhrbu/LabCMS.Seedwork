using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using LabCMS.Seedwork.Converters;

namespace LabCMS.Seedwork.FixtureDomain
{
    public record CheckinRecord:ICheckRecord
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey(nameof(CheckoutRecord))]
        public int CheckoutRecordId {get;set;}
        public CheckoutRecord? CheckoutRecord{get;set;}

        [ForeignKey(nameof(Applicant))]
        public string? ApplicantUserId { get; set; }
        public Role? Applicant { get; set; }

        [ForeignKey(nameof(Fixture))]
        public int FixtureNo { get; init; }
        public Fixture? Fixture { get; set; }

        [JsonConverter(typeof(JsonConverters.DateTimeOffsetJsonConverter))]
        public DateTimeOffset CheckinDate { get; set; }

        [ForeignKey(nameof(FixtureRoomApprover))]
        public string? FixtureRoomApproverId { get; set; }
        public Role? FixtureRoomApprover { get; set; }
        public CheckRecordStatus Status { get; set; } = CheckRecordStatus.Initial;

        [JsonConverter(typeof(JsonConverters.DateTimeOffsetJsonConverter))]
        public DateTimeOffset TimeStamp { get; init; } = DateTimeOffset.Now;
       
    }
}