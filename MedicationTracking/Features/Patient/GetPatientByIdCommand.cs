using MediatR;
using MedicationTracking.Models;
using Microsoft.AspNetCore.Mvc;

namespace MedicationTracking.Features.Patient;

public class GetPatientByIdCommand(int patientId) : IRequest<ActionResult<PatientDtoWithId>>
{
    public int PatientId { get; } = patientId;
}
