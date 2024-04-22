namespace MedicationTracking.Models;

public class MedicineBase(string genericName, string brandName)
{
    public string GenericName { get; set; } = genericName;
    public string BrandName { get; set; } = brandName;
}
