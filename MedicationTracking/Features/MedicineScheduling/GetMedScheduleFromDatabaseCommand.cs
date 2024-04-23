using Data.Models;
using MediatR;
using MedicationTracking.Models;
using Microsoft.AspNetCore.Mvc;

namespace MedicationTracking.Features.MedicineScheduling;

/// <summary>
///
/// </summary>
/// <param name="patientMedRequestDto"></param>
public class GetMedScheduleFromDatabaseCommand(PatientMedRequestDto patientMedRequestDto)
    : IRequest<ActionResult<List<MedicationSchedule>>>
{
    /// <summary>
    ///
    /// </summary>
    public PatientMedRequestDto PatientMedRequestDto { get; } = patientMedRequestDto;
}
