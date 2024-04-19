using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Models;

public class ScheduleChangeLog
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int ScheduleChangeId { get; set; }

    [Required]
    public int ScheduleId { get; set; }

    public int? OldTimeCategoryId { get; set; } // Nullable if change might not involve this
    public int? NewTimeCategoryId { get; set; } // Nullable if change might not involve this

    [StringLength(100)]
    public required string OldDosage { get; set; }

    [StringLength(100)]
    public required string NewDosage { get; set; }

    public DateTime? OldStart { get; set; } // Nullable if change might not involve this
    public DateTime? NewStart { get; set; } // Nullable if change might not involve this
    public DateTime? OldEnd { get; set; } // Nullable if change might not involve this
    public DateTime? NewEnd { get; set; } // Nullable if change might not involve this

    [ForeignKey("ScheduleId")]
    public virtual required MedicationSchedule MedicationSchedule { get; set; }

    [ForeignKey("OldTimeCategoryId")]
    public virtual required TimeCategory OldTimeCategory { get; set; }

    [ForeignKey("NewTimeCategoryId")]
    public virtual required TimeCategory NewTimeCategory { get; set; }
}