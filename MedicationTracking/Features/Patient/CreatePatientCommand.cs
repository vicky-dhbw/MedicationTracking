using MediatR;
using MedicationTracking.Models;

namespace MedicationTracking.Features.Patient;

public class CreatePatientCommand(PatientDto patient) : IRequest<PatientDto>
{
    public PatientDto Patient { get; } = patient;
}
