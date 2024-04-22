using MediatR;
using MedicationTracking.Models;
using Microsoft.AspNetCore.Mvc;

namespace MedicationTracking.Features.Patient;

/// <summary>
///
/// </summary>
/// <param name="patientDtoWithId"></param>
public class UpdatePatientInfoCommand(PatientDtoWithId patientDtoWithId)
    : IRequest<ActionResult<PatientDto>>
{
    /// <summary>
    ///
    /// </summary>
    public PatientDtoWithId PatientDtoWithId { get; } = patientDtoWithId;
}
