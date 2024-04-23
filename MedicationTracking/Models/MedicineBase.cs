namespace MedicationTracking.Models;

/// <summary>
/// 
/// </summary>
/// <param name="genericName"></param>
/// <param name="brandName"></param>
public class MedicineBase(string genericName, string brandName)
{
    /// <summary>
    /// 
    /// </summary>
    public string GenericName { get; set; } = genericName;
    /// <summary>
    /// 
    /// </summary>
    public string BrandName { get; set; } = brandName;
}
