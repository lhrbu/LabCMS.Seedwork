using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LabCMS.Seedwork.FixtureDomain
{
    public record CheckoutRecord:ICheckRecord
    {
        [Key]
        public int Id {get;set;}


        [ForeignKey(nameof(Applicant))]
        public string? ApplicantUserId { get; set; }
        public Role? Applicant { get; set; }


        [ForeignKey(nameof(Fixture))]
        public int FixtureNo {get; init; }
        public Fixture? Fixture {get;set;}

        public DateTimeOffset CheckoutDate {get;set;}
        public string ReceiverCompany {get; init; } =null!;
        public string Receiver {get; init; } = null!;
        public DateTimeOffset PlanndReturnDate {get; set; }

        [ForeignKey(nameof(TestRoomApprover))]
        public string? TestRoomApproverUserId {get;set;}
        public Role? TestRoomApprover {get;set;}

        [ForeignKey(nameof(FixtureRoomApprover))]
        public string? FixtureRoomApproverId {get;set;}
        public Role? FixtureRoomApprover {get;set;}
        public CheckRecordStatus Status { get; set; } = CheckRecordStatus.Initial;
        public DateTimeOffset TimeStamp { get; init; } = DateTimeOffset.Now;


    }
}