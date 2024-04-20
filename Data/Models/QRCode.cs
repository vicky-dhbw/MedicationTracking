using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Models;

public class QrCode
{
    [Key]
    [StringLength(255)]
    public string QrCodeValue { get; set; } = Guid.NewGuid().ToString();

    [Required]
    public int PatientId { get; set; }

    [ForeignKey("PatientId")]
    public virtual required Patient Patient { get; set; }
}
