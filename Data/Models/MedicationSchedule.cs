using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Models;

public class MedicationSchedule(int medicineId, int patientId, int timeCategoryId, string dosage, DateTime start, DateTime end)
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int ScheduleId { get; set; }

    [Required]
    public int MedicineId { get; set; } = medicineId;

    [Required]
    public int PatientId { get; set; } = patientId;

    [Required]
    public int TimeCategoryId { get; set; } = timeCategoryId;

    [Required, StringLength(100)]
    public string Dosage { get; set; } = dosage;

    [Required]
    public DateTime Start { get; set; } = start;

    [Required]
    public DateTime End { get; set; } = end;

    [ForeignKey("MedicineId")]
    public virtual Medicine? Medicine { get; set; }

    [ForeignKey("PatientId")]
    public virtual Patient? Patient { get; set; }

    [ForeignKey("TimeCategoryId")]
    public virtual TimeCategory? TimeCategory { get; set; }
}
