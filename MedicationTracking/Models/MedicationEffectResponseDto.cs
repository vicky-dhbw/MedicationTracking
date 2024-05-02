namespace MedicationTracking.Models;

/// <summary>
/// 
/// </summary>
/// <param name="effectId"></param>
/// <param name="medicineId"></param>
/// <param name="gender"></param>
/// <param name="description"></param>
public class MedicationEffectResponseDto(
    int effectId,
    int medicineId,
    string gender,
    string? description
) : MedicationEffectBase(gender, description)
{
    /// <summary>
    /// 
    /// </summary>
    public int EffectId { get; set; } = effectId;

    /// <summary>
    /// 
    /// </summary>
    public int MedicineId { get; set; } = medicineId;
}
