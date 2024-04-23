using Ardalis.Specification;
using Data.Models;

namespace MedicationTracking.Specifications;

/// <summary>
///
/// </summary>
public sealed class AllSchdulesForMedicineIdSpec : Specification<MedicationSchedule>
{
    /// <summary>
    ///
    /// </summary>
    /// <param name="medicineId"></param>
    public AllSchdulesForMedicineIdSpec(int medicineId)
    {
        Query.Where(ms => ms.MedicineId == medicineId);
    }
}
