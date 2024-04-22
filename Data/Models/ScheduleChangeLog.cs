using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Models;

/// <summary>
///
/// </summary>
/// <param name="scheduleId"></param>
/// <param name="oldTimeCategoryId"></param>
/// <param name="newTimeCategoryId"></param>
/// <param name="oldDosage"></param>
/// <param name="newDosage"></param>
/// <param name="oldStart"></param>
/// <param name="newStart"></param>
/// <param name="oldEnd"></param>
/// <param name="newEnd"></param>
public class ScheduleChangeLog(
    int scheduleId,
    int? oldTimeCategoryId,
    int? newTimeCategoryId,
    string oldDosage,
    string newDosage,
    DateTime? oldStart,
    DateTime? newStart,
    DateTime? oldEnd,
    DateTime? newEnd
)
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int ScheduleChangeId { get; set; }

    [Required]
    public int ScheduleId { get; set; } = scheduleId;

    public int? OldTimeCategoryId { get; set; } = oldTimeCategoryId; // Nullable if change might not involve this
    public int? NewTimeCategoryId { get; set; } = newTimeCategoryId; // Nullable if change might not involve this

    [StringLength(100)]
    public string OldDosage { get; set; } = oldDosage;

    [StringLength(100)]
    public string NewDosage { get; set; } = newDosage;

    public DateTime? OldStart { get; set; } = oldStart; // Nullable if change might not involve this
    public DateTime? NewStart { get; set; } = newStart; // Nullable if change might not involve this
    public DateTime? OldEnd { get; set; } = oldEnd; // Nullable if change might not involve this
    public DateTime? NewEnd { get; set; } = newEnd; // Nullable if change might not involve this

    [ForeignKey("ScheduleId")]
    public virtual MedicationSchedule? MedicationSchedule { get; set; }

    [ForeignKey("OldTimeCategoryId")]
    public virtual TimeCategory? OldTimeCategory { get; set; }

    [ForeignKey("NewTimeCategoryId")]
    public virtual TimeCategory? NewTimeCategory { get; set; }
}
