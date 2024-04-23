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
    /// Schedule a medication for patient
    /// </summary>
    /// <param name="medicineScheduleDto"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    [HttpPost]
    public async Task<ActionResult<MedicineSchedulingSingelDto>> ScheduleSingleMedication(
        [FromBody] [Required] MedicineScheduleDto medicineScheduleDto,
        CancellationToken cancellationToken
    )
    {
        return await _mediator.Send(
            new CreateMedScheduleCommand(medicineScheduleDto),
            cancellationToken
        );
    }

    /// <summary>
    /// Get a medication schedule for a patient
    /// </summary>
    /// <param name="genericName"></param>
    /// <param name="brandNName"></param>
    /// <param name="patientId"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    [HttpGet]
    [Route("SingleMedForPatient")]
    public async Task<ActionResult<List<MedicineSchedulingSingelDto>>> GetSingleMedScheduleAsync(
        [FromQuery] [Required] string genericName,
        [Required] [FromQuery] string brandNName,
        [Required] [FromQuery] int patientId,
        CancellationToken cancellationToken
    )
    {
        return await _mediator.Send(
            new GetMedScheduleCommand(new PatientMedRequestDto(genericName, brandNName, patientId)),
            cancellationToken
        );
    }

    /// <summary>
    /// Edit a medication schedule of a patient
    /// </summary>
    /// <param name="medicineScheduleBase"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    [HttpPost]
    [Route("EditMedSchedule")]
    public async Task<ActionResult<MedicineSchedulingSingelDto>> EditMedScheduleAsync(
        [FromBody] [Required] MedicineScheduleBase medicineScheduleBase,
        CancellationToken cancellationToken
    )
    {
        return await _mediator.Send(
            new EditMedScheduleCommand(medicineScheduleBase),
            cancellationToken
        );
    }

    /// <summary>
    /// Get all medicine schedules of a patient
    /// </summary>
    /// <param name="patientId"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    [HttpGet]
    [Route("AllMedForPatient/{patientId}")]
    public async Task<ActionResult<MedicineSchedulingMultipleDto>> GetAllMedForPatientAsync(
        [FromRoute] int patientId,
        CancellationToken cancellationToken
    )
    {
        return await _mediator.Send(new GetAllMedsForPatientCommand(patientId), cancellationToken);
    }
}
