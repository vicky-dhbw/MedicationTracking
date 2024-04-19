using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Models;

public class MedicationSchedule
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int ScheduleId { get; set; }

    [Required]
    public int MedicineId { get; set; }

    [Required]
    public int PatientId { get; set; }

    [Required]
    public int TimeCategoryId { get; set; }

    [Required, StringLength(100)]
    public required string Dosage { get; set; }

    [Required]
    public DateTime Start { get; set; }

    [Required]
    public DateTime End { get; set; }

    [ForeignKey("MedicineId")]
    public virtual required Medicine Medicine { get; set; }

    [ForeignKey("PatientId")]
    public virtual  required Patient Patient { get; set; }

    [ForeignKey("TimeCategoryId")]
    public virtual required TimeCategory TimeCategory { get; set; }
}