using Ardalis.Specification;
using Data.Models;

namespace MedicationTracking.Specifications;

/// <summary>
/// 
/// </summary>
public sealed class MedScheduleByPatientIdSpec : Specification<MedicationSchedule>
{
    /// <summary>
    /// 
    /// </summary>
    /// <param name="patientId"></param>
    public MedScheduleByPatientIdSpec(int patientId)
    {
        Query.Where(ms => ms.PatientId == patientId);
    }
}