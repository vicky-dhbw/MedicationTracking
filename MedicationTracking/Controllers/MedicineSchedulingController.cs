using System.ComponentModel.DataAnnotations;
using MediatR;
using MedicationTracking.Features.MedicineScheduling;
using MedicationTracking.Models;
using Microsoft.AspNetCore.Mvc;

namespace MedicationTracking.Controllers;

/// <summary>
/// Controller for medication scheduling
/// </summary>
/// <param name="mediator"></param>
[Route("api/[controller]")]
public class MedicineSchedulingController(IMediator mediator) : ControllerBase
{
    /// <summary>
    /// mediator to send command
    /// </summary>
    private readonly IMediator _mediator = mediator;
    /// <summary>
    /// 
    /// </summary>
    /// <param name="medicineScheduleDto"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    [HttpPost]
    public async Task<ActionResult<MedicineSchedulingSingelDto>> ScheduleSingleMedication([FromBody] [Required] MedicineScheduleDto medicineScheduleDto, CancellationToken cancellationToken)
    {
        return await _mediator.Send(new CreateMedScheduleCommand(medicineScheduleDto), cancellationToken);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="patientMedRequestDto"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    [HttpGet]
    public async Task<ActionResult<MedicineSchedulingSingelDto>> GetMedSchedule(
        [FromBody] [Required] PatientMedRequestDto patientMedRequestDto, CancellationToken cancellationToken)
    {
        return await _mediator.Send(new GetMedScheduleCommand(patientMedRequestDto), cancellationToken);
    }
}