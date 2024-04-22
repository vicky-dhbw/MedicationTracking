using Ardalis.Specification;
using Data.Models;
using MedicationTracking.Models;

namespace MedicationTracking.Specifications;

public sealed class SameGenericAndBrandNameSpec : Specification<Medicine>
{
    public SameGenericAndBrandNameSpec(MedicineBase medicine)
    {
        Query.Where(m =>
            m.BrandName == medicine.BrandName && m.GenericName == medicine.GenericName
        );
    }
}
