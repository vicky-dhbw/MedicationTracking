namespace MedicationTracking.Models;

/// <summary>
///
/// </summary>
/// <param name="effectId"></param>
/// <param name="gender"></param>
/// <param name="description"></param>
public class MedicationEffectWithId(int effectId, string gender, string description)
    : MedicationEffectBase(gender, description)
{
    /// <summary>
    ///
    /// </summary>
    public int EffectId { get; set; } = effectId;
}
