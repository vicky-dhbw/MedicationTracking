namespace MedicationTracking.Models;

/// <summary>
///
/// </summary>
public class MedicineSchedulingSingelDto(
    int scheduleId,
    int medicineId,
    int patientId,
    string timeCategory,
    string dosage,
    DateTime start,
    DateTime end
) : MedicineScheduleBase(scheduleId, medicineId, timeCategory, dosage, start, end)
{
    /// <summary>
    /// Patient id of the medication schedule
    /// </summary>
    public int PatientId { get; set; } = patientId;

}
