namespace MedicationTracking.Models;

/// <summary>
///
/// </summary>
public class MedInfoScheduleInfo
{
    /// <summary>
    ///
    /// </summary>
    public MedicineDto MedicineDto { get; set; } = null!;

    /// <summary>
    ///
    /// </summary>
    public MedicineScheduleBase MedicineScheduleBase { get; set; } = null!;

    /// <summary>
    ///
    /// </summary>
    public MedAdministrationLogBaseWithId? MedAdministrationLog { get; set; }
}
