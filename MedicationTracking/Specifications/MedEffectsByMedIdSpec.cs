using Ardalis.Specification;
using Data.Models;

namespace MedicationTracking.Specifications;

public sealed class MedEffectsByMedIdSpec : Specification<MedicationEffect>
{
    public MedEffectsByMedIdSpec(int medicineId)
    {
        Query.Where(e => e.MedicineId == medicineId);
    }
}
