using Data.Models;

namespace MedicationTracking.Models;

public class MedicationEffectRequestDto(
    string genericName,
    string brandName,
    string gender,
    string? description
) : MedicineBase(genericName, brandName)
{
    public required string Gender { get; set; } = gender;

    public string? Description { get; set; } = description;
}
