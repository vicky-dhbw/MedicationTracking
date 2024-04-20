using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Models;

public class Medicine(
    string genericName,
    string brandName,
    string color,
    string form,
    string? administrationMethod
)
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int MedicineId { get; set; }

    [StringLength(100)]
    public string GenericName { get; set; } = genericName;

    [StringLength(100)]
    public string BrandName { get; set; } = brandName;

    [StringLength(100)]
    public string Color { get; set; } = color;

    [StringLength(100)]
    public string Form { get; set; } = form;

    [StringLength(255)]
    public string? AdministrationMethod { get; set; } = administrationMethod;
}
