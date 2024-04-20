using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Models;

public class MedicationEffect
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int EffectId { get; set; }

    [Required]
    public int MedicineId { get; set; }

    [Required, StringLength(24)]
    public required string Gender { get; set; }

    [StringLength(255)]
    public string? Description { get; set; }

    [ForeignKey("MedicineId")]
    public virtual required Medicine Medicine { get; set; }
}
