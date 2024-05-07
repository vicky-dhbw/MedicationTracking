using Ardalis.Specification;
using Data.Models;

namespace MedicationTracking.Specifications;

/// <summary>
/// 
/// </summary>
public sealed class PatientByIdSpec : Specification<Patient>
{
    /// <summary>
    /// 
    /// </summary>
    /// <param name="patientId"></param>
    public PatientByIdSpec(int patientId)
    {
        Query.Where(p => p.PatientId == patientId);
    }
}
