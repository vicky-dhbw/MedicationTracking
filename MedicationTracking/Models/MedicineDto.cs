using Data.Models;

namespace MedicationTracking.Models;

public class MedicineDto(
    string genericName,
    string brandName,
    string color,
    string form,
    string? administrationMethod
) : MedicineBase(genericName, brandName)
{
    public string Color { get; set; } = color;

    public string Form { get; set; } = form;

    public string? AdministrationMethod { get; set; } = administrationMethod;

    public static implicit operator MedicineDto(Medicine medicine)
    {
        return new MedicineDto(
            medicine.GenericName,
            medicine.BrandName,
            medicine.Color,
            medicine.Form,
            medicine.AdministrationMethod
        );
    }
}
