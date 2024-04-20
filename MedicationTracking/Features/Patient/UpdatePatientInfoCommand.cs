using MediatR;
using MedicationTracking.Models;
using Microsoft.AspNetCore.Mvc;

namespace MedicationTracking.Features.Patient;

public class UpdatePatientInfoCommand(PatientDtoWithId patientDtoWithId)
    : IRequest<ActionResult<PatientDto>>
{
    public PatientDtoWithId PatientDtoWithId { get; } = patientDtoWithId;
}
