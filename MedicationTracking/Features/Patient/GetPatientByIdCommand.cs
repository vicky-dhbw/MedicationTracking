using MediatR;
using MedicationTracking.Models;

namespace MedicationTracking.Features.Patient;

public class GetPatientByIdCommand (int patientId) : IRequest<PatientDtoWithId>
{
    public int PatientId { get; } = patientId;
}