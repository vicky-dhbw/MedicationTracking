using Ardalis.Specification;
using Data.Models;

namespace MedicationTracking.Specifications;

/// <summary>
/// 
/// </summary>
public sealed class MedAdminLogByScheduleIdSpec : Specification<MedAdministrationLog>
{
    /// <summary>
    /// 
    /// </summary>
    /// <param name="scheduleId"></param>
    public MedAdminLogByScheduleIdSpec(int scheduleId)
    {
        Query.Where(mal => mal.ScheduleId == scheduleId);
    }
}