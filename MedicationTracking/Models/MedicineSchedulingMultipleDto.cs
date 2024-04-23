namespace MedicationTracking.Models;

/// <summary>
///
/// </summary>
public class MedicineSchedulingMultipleDto
{
    /// <summary>
    /// patient base information
    /// </summary>
    public PatientBase Patient { get; set; } = null!;

    /// <summary>
    /// list of all medicine schedule for the patient
    /// </summary>
    public List<MedInfoScheduleInfo> MedicineSchedules { get; set; } = null!;
}
