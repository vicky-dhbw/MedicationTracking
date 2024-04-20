using MediatR;
using MedicationTracking.Features.Patient;
using MedicationTracking.Models;
using Microsoft.AspNetCore.Mvc;

namespace MedicationTracking.Controllers;

[Route("api/[controller]")]
public class PatientController(IMediator mediator) : ControllerBase
{
    protected readonly IMediator _mediator = mediator;

    [HttpPost]
    public async Task<ActionResult<PatientDto>> CreatePatientAsync(
        [FromBody] PatientDto patient,
        CancellationToken cancellationToken
    )
    {
        return await _mediator.Send(new CreatePatientCommand(patient), cancellationToken);
    }

    [HttpGet("{patientId}")]
    public async Task<ActionResult<PatientDtoWithId>> GetPatientAsync(
        [FromRoute] int patientId,
        CancellationToken cancellationToken
    )
    {
        return await _mediator.Send(new GetPatientByIdCommand(patientId), cancellationToken);
    }

    [HttpPut]
    [Route("UpdatePatientInfo")]
    public async Task<ActionResult<PatientDto>> UpdatePatientInfoAsync(
        [FromBody] PatientDtoWithId patient,
        CancellationToken cancellationToken
    )
    {
        return await _mediator.Send(new UpdatePatientInfoCommand(patient), cancellationToken);
    }

    [HttpDelete]
    [Route("{patientId}")]
    public async Task<ActionResult> DeletePatientAsync(
        [FromRoute] int patientId,
        CancellationToken cancellationToken
    )
    {
        return await _mediator.Send(new DeletePatientCommand(patientId), cancellationToken);
    }
}
