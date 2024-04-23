using System.ComponentModel.DataAnnotations;
using MediatR;
using MedicationTracking.Features.Patient;
using MedicationTracking.Models;
using Microsoft.AspNetCore.Mvc;

namespace MedicationTracking.Controllers;

/// <summary>
/// Controller for medicine management
/// </summary>
/// <param name="mediator"></param>
[Route("api/[controller]")]
public class PatientController(IMediator mediator) : ControllerBase
{
    /// <summary>
    ///
    /// </summary>
    private readonly IMediator _mediator = mediator;

    /// <summary>
    /// Create a Patient and save it in the database
    /// </summary>
    /// <param name="patient"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    [HttpPost]
    public async Task<ActionResult<PatientDtoWithId>> CreatePatientAsync(
        [FromBody] [Required] PatientDto patient,
        CancellationToken cancellationToken
    )
    {
        return await _mediator.Send(new CreatePatientCommand(patient), cancellationToken);
    }

    /// <summary>
    /// Get a Patient from patientId
    /// </summary>
    /// <param name="patientId"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    [HttpGet("{patientId}")]
    public async Task<ActionResult<PatientDtoWithId>> GetPatientAsync(
        [FromRoute] [Required] int patientId,
        CancellationToken cancellationToken
    )
    {
        return await _mediator.Send(new GetPatientByIdCommand(patientId), cancellationToken);
    }

    /// <summary>
    /// Update Info for a Patient
    /// </summary>
    /// <param name="patient"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    [HttpPut]
    [Route("UpdatePatientInfo")]
    public async Task<ActionResult<PatientDto>> UpdatePatientInfoAsync(
        [FromBody] [Required] PatientDtoWithId patient,
        CancellationToken cancellationToken
    )
    {
        return await _mediator.Send(new UpdatePatientInfoCommand(patient), cancellationToken);
    }

    /// <summary>
    /// Delete a Patient from the database
    /// </summary>
    /// <param name="patientId"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    [HttpDelete]
    [Route("{patientId}")]
    public async Task<ActionResult> DeletePatientAsync(
        [FromRoute] [Required] int patientId,
        CancellationToken cancellationToken
    )
    {
        return await _mediator.Send(new DeletePatientCommand(patientId), cancellationToken);
    }

    /// <summary>
    ///
    /// </summary>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    [HttpGet]
    [Route("AllPatients")]
    public async Task<ActionResult<List<PatientDtoWithId>>> GetAllPatientsAsync(
        CancellationToken cancellationToken
    )
    {
        return await _mediator.Send(new GetAllPatientsCommand(), cancellationToken);
    }

    /// <summary>
    ///
    /// </summary>
    /// <param name="qrCodeValue"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    [HttpGet]
    [Route("GetPatient/{qrCodeValue}")]
    public async Task<ActionResult<PatientBase>> GetPatientByQrCodeValue(
        string qrCodeValue,
        CancellationToken cancellationToken
    )
    {
        return await _mediator.Send(new GetPatientByQrCodeCommand(qrCodeValue), cancellationToken);
    }
}
