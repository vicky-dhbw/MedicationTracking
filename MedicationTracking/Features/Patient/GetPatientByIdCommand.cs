using MediatR;
using MedicationTracking.Models;
using Microsoft.AspNetCore.Mvc;

namespace MedicationTracking.Features.Patient;

/// <summary>
///
/// </summary>
/// <param name="patientId"></param>
public class GetPatientByIdCommand(int patientId) : IRequest<ActionResult<PatientDtoWithId>>
{
    /// <summary>
    ///
    /// </summary>
    public int PatientId { get; } = patientId;
}
