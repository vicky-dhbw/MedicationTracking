using Ardalis.Specification;
using Data.Models;

namespace MedicationTracking.Specifications;

public sealed class MedicineByIdSpec : Specification<Medicine>
{
    public MedicineByIdSpec(int medicineId)
    {
        Query.Where(m => m.MedicineId == medicineId);
    }
}
