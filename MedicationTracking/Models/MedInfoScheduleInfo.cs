namespace MedicationTracking.Models;

/// <summary>
/// 
/// </summary>
public class MedInfoScheduleInfo
{
    /// <summary>
    /// 
    /// </summary>
    public MedicineBase MedicineBase { get; set; } = null!;
    
    /// <summary>
    /// 
    /// </summary>
    public MedicineScheduleBase MedicineScheduleBase { get; set; } = null!;
}