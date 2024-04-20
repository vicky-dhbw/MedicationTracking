using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Models;

public class MedAdministrationLog
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int MedLogId { get; set; }

    [Required]
    public int ScheduleId { get; set; }

    [Required]
    public DateTime MedAdminTime { get; set; }

    [Required]
    public int MedAdminStatus { get; set; }

    [StringLength(1000)]
    public string? MedAdminNote { get; set; }

    [ForeignKey("ScheduleId")]
    public virtual MedicationSchedule? MedicationSchedule { get; set; }
}
