namespace MedicationTracking.Models;

/// <summary>
/// 
/// </summary>
public class MedicineScheduleBase(int scheduleId, int medicineId, string timeCategory, string dosage, DateTime start, DateTime end)
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
    /// Time at which the medicine needs to be taken
    /// </summary>
    public string TimeCategory { get; set; } = timeCategory;

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