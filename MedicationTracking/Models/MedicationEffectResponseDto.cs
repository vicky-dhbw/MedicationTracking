namespace MedicationTracking.Models;

public class MedicationEffectResponseDto(
    int effectId,
    int medicineId,
    string gender,
    string? description
) : MedicationEffectBase(gender, description)
{
    public int EffectId { get; set; } = effectId;

    public int MedicineId { get; set; } = medicineId;
}
