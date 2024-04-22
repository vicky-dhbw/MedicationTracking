using MediatR;
using MedicationTracking.Models;

namespace MedicationTracking.Features.Patient;

/// <summary>
///
/// </summary>
/// <param name="patient"></param>
public class CreatePatientCommand(PatientDto patient) : IRequest<PatientDtoWithId>
{
    /// <summary>
    ///
    /// </summary>
    public PatientDto Patient { get; } = patient;
}
