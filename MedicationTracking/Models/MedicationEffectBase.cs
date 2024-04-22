namespace MedicationTracking.Models;

public class MedicationEffectBase(string gender, string description)
{
    public string Gender { get; set; } = gender;
    public string Description { get; set; } = description;
}
