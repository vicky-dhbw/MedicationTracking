namespace MedicationTracking.Models;

public class MedicineDtoWithEffects(
    string genericName,
    string brandName,
    string color,
    string form,
    string? administrationMethod
) : MedicineDto(genericName, brandName, color, form, administrationMethod)
{
    public List<MedicationEffectBase> MedicationEffects { get; set; }
}
