namespace MedicationTracking.Models;

/// <summary>
///
/// </summary>
/// <param name="genericName"></param>
/// <param name="brandName"></param>
/// <param name="color"></param>
/// <param name="form"></param>
/// <param name="administrationMethod"></param>
public class MedicineDtoWithEffects(
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
    public List<MedicationEffectWithId> MedicationEffects { get; set; }
}
