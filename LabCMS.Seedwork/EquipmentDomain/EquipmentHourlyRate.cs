using System.ComponentModel.DataAnnotations;

namespace LabCMS.Seedwork.EquipmentDomain
{
    public class EquipmentHourlyRate
    {
        [Key]
        public string EquipmentNo { get; set; } = null!;
        public string EquipmentName { get; set; } = null!;
        public string MachineCategory { get; set; } = null!;
        public string HourlyRate { get; set; } = null!;
    }
}