namespace MedicationTracking.Models;
/// <summary>
/// 
/// </summary>
public class MedicineScheduleDto(string genericName, string brandName, int patientId, string timeCategory, string dosage, DateTime start, DateTime end) : MedicineBase(genericName, brandName)
{
    /// <summary>
    /// Patient id of the medicine to which the medicine is to be given
    /// </summary>
    public int PatientId { get; set; } = patientId;

    /// <summary>
    /// When should the medicine be taken?
    /// </summary>
    public string TimeCategory { get; set; } = timeCategory;

    /// <summary>
    /// The dosage of the medication
    /// </summary>
    public required string Dosage { get; set; } = dosage;

    /// <summary>
    /// The start date of the medication
    /// </summary>
    public DateTime Start { get; set; } = start;

    /// <summary>
    /// The end date of the medication
    /// </summary>
    public DateTime End { get; set; } = end;
}