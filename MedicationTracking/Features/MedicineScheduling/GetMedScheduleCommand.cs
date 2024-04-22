using MediatR;
using MedicationTracking.Models;
using Microsoft.AspNetCore.Mvc;

namespace MedicationTracking.Features.MedicineScheduling;

/// <summary>
/// The request to get a single med schedule 
/// </summary>
public class GetMedScheduleCommand(PatientMedRequestDto patientMedRequestDto) : IRequest<ActionResult<MedicineSchedulingSingelDto>>
{
    /// <summary>
    /// The dto object received by the controller is passed here
    /// </summary>
    public PatientMedRequestDto PatientMedRequestDto { get; } = patientMedRequestDto;
}