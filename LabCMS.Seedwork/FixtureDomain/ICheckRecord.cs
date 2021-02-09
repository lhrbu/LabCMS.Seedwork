using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabCMS.Seedwork.FixtureDomain
{
    public interface ICheckRecord
    {
        int Id { get; set; }
        DateTimeOffset TimeStamp { get; init; }
        CheckRecordStatus Status { get; set; }
        string? ApplicantUserId { get; set; }
    }
}