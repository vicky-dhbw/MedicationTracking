namespace MedicationTracking.Models;

/// <summary>
/// Request for a medicine schedule
/// </summary>
/// <param name="genericName"></param>
/// <param name="brandName"></param>
/// <param name="patietId"></param>
public class PatientMedRequestDto(string genericName, string brandName, int patietId)
    : MedicineBase(genericName, brandName)
{
    /// <summary>
    /// Id of the patient
    /// </summary>
    public int PatientId { get; set; } = patietId;
}
