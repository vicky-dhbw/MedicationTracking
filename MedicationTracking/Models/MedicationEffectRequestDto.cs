using Data.Models;

namespace MedicationTracking.Models;

/// <summary>
/// 
/// </summary>
/// <param name="genericName"></param>
/// <param name="brandName"></param>
/// <param name="gender"></param>
/// <param name="description"></param>
public class MedicationEffectRequestDto(
    string genericName,
    string brandName,
    string gender,
    string? description
) : MedicineBase(genericName, brandName)
{
    /// <summary>
    /// 
    /// </summary>
    public required string Gender { get; set; } = gender;

    /// <summary>
    /// 
    /// </summary>
    public string? Description { get; set; } = description;
}
