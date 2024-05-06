namespace MedicationTracking.Models;

/// <summary>
///
/// </summary>
/// <param name="gender"></param>
/// <param name="description"></param>
public class MedicationEffectBase(string gender, string description)
{
    /// <summary>
    ///
    /// </summary>
    public string Gender { get; set; } = gender;

    /// <summary>
    ///
    /// </summary>
    public string Description { get; set; } = description;
}
