using Ardalis.Specification;
using Data.Models;

namespace MedicationTracking.Specifications;

public sealed class PatientByIdSpec : Specification<Patient>
{
    public PatientByIdSpec(int patientId)
    {
        Query.Where(p => p.PatientId == patientId);
    }
}
