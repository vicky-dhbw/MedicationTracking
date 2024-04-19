using MediatR;
using MedicationTracking.Models;
using Microsoft.AspNetCore.Mvc;

namespace MedicationTracking.Controllers;

[Route("api/[controller]")]
public class PatientController(IMediator mediator) : ControllerBase
{
    protected readonly IMediator _mediator = mediator;

    [HttpPost]
    public async Task<ActionResult<PatientDto>> CreatePatientAsync([FromBody] PatientDto patient,
        CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    [HttpGet("{patientId}")]
    public async Task<ActionResult<PatientDto>> GetPatientAsync([FromRoute] int patientId, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    [HttpPut]
    [Route("UpdatePatientInfo")]
    public async Task<ActionResult<PatientDto>> UpdatePatientInfoAsync([FromBody] PatientDto patient,
        CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    [HttpDelete]
    [Route("{patientId}")]
    public async Task<ActionResult> DeletePatientAsync([FromRoute] string patientId,
        CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}