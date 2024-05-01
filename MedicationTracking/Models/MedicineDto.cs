using Data.Models;

namespace MedicationTracking.Models;

/// <summary>
/// 
/// </summary>
/// <param name="genericName"></param>
/// <param name="brandName"></param>
/// <param name="color"></param>
/// <param name="form"></param>
/// <param name="administrationMethod"></param>
public class MedicineDto(
    string genericName,
    string brandName,
    string color,
    string form,
    string? administrationMethod
) : MedicineBase(genericName, brandName)
{
    /// <summary>
    /// 
    /// </summary>
    public string Color { get; set; } = color;

    /// <summary>
    /// 
    /// </summary>
    public string Form { get; set; } = form;

    /// <summary>
    /// 
    /// </summary>
    public string? AdministrationMethod { get; set; } = administrationMethod;

    /// <summary>
    /// 
    /// </summary>
    /// <param name="medicine"></param>
    /// <returns></returns>
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
