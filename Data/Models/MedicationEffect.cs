using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Models;

public class MedicationEffect(int medicineId, string gender, string? description)
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int EffectId { get; set; }

    [Required]
    public int MedicineId { get; set; } = medicineId;

    [Required, StringLength(24)]
    public string Gender { get; set; } = gender;

    [StringLength(255)]
    public string? Description { get; set; } = description;

    [ForeignKey("MedicineId")]
    public virtual required Medicine Medicine { get; set; }
}
