namespace MedicationTracking.Models;

/// <summary>
///
/// </summary>
public class AllMedSchedulesDto
{
    /// <summary>
    /// patient base information
    /// </summary>
    public PatientBase Patient { get; set; } = null!;

    /// <summary>
    /// list of all medicine schedule for the patient
    /// </summary>
    public List<MedInfoScheduleInfoBase> MedicineSchedules { get; set; } = null!;
}
