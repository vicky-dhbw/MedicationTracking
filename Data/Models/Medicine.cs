using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Models;

public class Medicine
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int MedicineId { get; set; }

    [StringLength(100)]
    public required string GenericName { get; set; }

    [StringLength(100)]
    public required string BrandName { get; set; }

    [StringLength(100)]
    public required string Color { get; set; }

    [StringLength(100)]
    public required string Form { get; set; }

    [StringLength(255)]
    public string? AdministrationMethod { get; set; }
}
