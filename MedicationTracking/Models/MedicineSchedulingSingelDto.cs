namespace MedicationTracking.Models;
/// <summary>
/// 
/// </summary>
public class MedicineSchedulingSingelDto(int scheduleId, int medicineId, int patientId, string timeCategoryId, string dosage, DateTime start, DateTime end)
{
    /// <summary>
    /// Schedule id of the medication schedule
    /// </summary>
    public int ScheduleId { get; set; } = scheduleId;

    /// <summary>
    /// medicine id of the medication schedule
    /// </summary>
    public int MedicineId { get; set; } = medicineId;

    /// <summary>
    /// Patient id of the medication schedule
    /// </summary>
    public int PatientId { get; set; } = patientId;

    /// <summary>
    /// Time at which the medicine needs to be taken
    /// </summary>
    public string TimeCategory { get; set; } = timeCategoryId;

    /// <summary>
    /// Dosage of the medication
    /// </summary>
    public string Dosage { get; set; } = dosage;

    /// <summary>
    /// Start day of the medication
    /// </summary>
    public DateTime Start { get; set; } = start;

    /// <summary>
    /// End date of the medication
    /// </summary>
    public DateTime End { get; set; } = end;
}