using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace MedicationTracking.Features.Patient;

/// <summary>
///
/// </summary>
/// <param name="patientId"></param>
public class DeletePatientCommand(int patientId) : IRequest<ActionResult>
{
    /// <summary>
    ///
    /// </summary>
    public int PatientId { get; } = patientId;
}
