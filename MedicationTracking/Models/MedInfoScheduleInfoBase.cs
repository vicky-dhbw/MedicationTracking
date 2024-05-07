namespace MedicationTracking.Models;

/// <summary>
///
/// </summary>
public class MedInfoScheduleInfoBase
{
    /// <summary>
    ///
    /// </summary>
    public MedicineDto MedicineDto { get; set; } = null!;

    /// <summary>
    ///
    /// </summary>
    public MedicineScheduleBase MedicineScheduleBase { get; set; } = null!;
}
