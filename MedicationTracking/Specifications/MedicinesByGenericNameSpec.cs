using Ardalis.Specification;
using Data.Models;

namespace MedicationTracking.Specifications;

public sealed class MedicinesByGenericNameSpec : Specification<Medicine>
{
    public MedicinesByGenericNameSpec(string genericName)
    {
        Query.Where(m => m.GenericName == genericName);
    }
}
