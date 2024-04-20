using Data.Models;

namespace MedicationTracking.Models;

public class MedicineDtoWithId(
    int medicineId,
    string genericName,
    string brandName,
    string color,
    string form,
    string? administrationMethod
) : MedicineDto(genericName, brandName, color, form, administrationMethod)
{
    public int MedicineId { get; set; } = medicineId;

    public static implicit operator MedicineDtoWithId(Medicine medicine)
    {
        return new MedicineDtoWithId(
            medicine.MedicineId,
            medicine.GenericName,
            medicine.BrandName,
            medicine.Color,
            medicine.Form,
            medicine.AdministrationMethod
        );
    }
}
