using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Models;

public class MedAdministrationLog(
    int scheduleId,
    DateTime medAdminTime,
    int medAdminStatus,
    string? medAdminNote
)
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int MedLogId { get; set; }

    [Required]
    public int ScheduleId { get; set; } = scheduleId;

    [Required]
    public DateTime MedAdminTime { get; set; } = medAdminTime;

    [Required]
    public int MedAdminStatus { get; set; } = medAdminStatus;

    [StringLength(1000)]
    public string? MedAdminNote { get; set; } = medAdminNote;

    [ForeignKey("ScheduleId")]
    public virtual MedicationSchedule? MedicationSchedule { get; set; }
}
