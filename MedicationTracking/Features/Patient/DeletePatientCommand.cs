using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace MedicationTracking.Features.Patient;

public class DeletePatientCommand(int patientId) : IRequest<ActionResult>
{
    public int PatientId { get; } = patientId;
}
