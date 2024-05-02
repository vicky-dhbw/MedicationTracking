using Ardalis.Specification;
using Data.Models;
using MedicationTracking.Models;

namespace MedicationTracking.Specifications;

/// <summary>
/// 
/// </summary>
public sealed class SameGenericAndBrandNameSpec : Specification<Medicine>
{
    /// <summary>
    /// 
    /// </summary>
    /// <param name="medicine"></param>
    public SameGenericAndBrandNameSpec(MedicineBase medicine)
    {
        Query.Where(m =>
            m.BrandName == medicine.BrandName && m.GenericName == medicine.GenericName
        );
    }
}
