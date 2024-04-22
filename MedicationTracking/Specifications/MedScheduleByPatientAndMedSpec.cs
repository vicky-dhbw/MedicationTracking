using Ardalis.Specification;
using Data.Models;

namespace MedicationTracking.Specifications;

/// <summary>
/// Specification for medicine schedule where patientId and medicine matches
/// </summary>
public sealed class MedScheduleByPatientAndMedSpec : Specification<MedicationSchedule>
{
    /// <summary>
    /// Primary constructor containing the query
    /// </summary>
    /// <param name="patientId"></param>
    /// <param name="medicineId"></param>
    public MedScheduleByPatientAndMedSpec(int patientId, int medicineId)
    {
        Query.Where(m => m.MedicineId == medicineId && m.PatientId == patientId);
    }
}