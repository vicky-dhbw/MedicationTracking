using Ardalis.Specification;
using Data.Models;

namespace MedicationTracking.Specifications;

/// <summary>
///
/// </summary>
public sealed class MedScheduleByIdSpec : Specification<MedicationSchedule>
{
    /// <summary>
    ///
    /// </summary>
    /// <param name="scheduleId"></param>
    public MedScheduleByIdSpec(int scheduleId)
    {
        Query.Where(ms => ms.ScheduleId == scheduleId);
    }
}
