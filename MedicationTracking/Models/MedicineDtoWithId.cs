using Data.Models;

namespace MedicationTracking.Models;

/// <summary>
/// 
/// </summary>
/// <param name="medicineId"></param>
/// <param name="genericName"></param>
/// <param name="brandName"></param>
/// <param name="color"></param>
/// <param name="form"></param>
/// <param name="administrationMethod"></param>
public class MedicineDtoWithId(
    int medicineId,
    string genericName,
    string brandName,
    string color,
    string form,
    string? administrationMethod
) : MedicineDto(genericName, brandName, color, form, administrationMethod)
{
    /// <summary>
    /// 
    /// </summary>
    public int MedicineId { get; set; } = medicineId;

    /// <summary>
    /// 
    /// </summary>
    /// <param name="medicine"></param>
    /// <returns></returns>
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
