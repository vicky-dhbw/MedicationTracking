using MediatR;
using MedicationTracking.Features.MedAdministrationLog;
using MedicationTracking.Models;
using Microsoft.AspNetCore.Mvc;

namespace MedicationTracking.Controllers;
/// <summary>
/// 
/// </summary>
/// <param name="mediator"></param>

[Route("api/[controller]")]
public class MedAdministrationLogController(IMediator mediator) : ControllerBase
{
    /// <summary>
    /// 
    /// </summary>
    /// <param name="administrationLogBase"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    [HttpPost]
    public async Task<ActionResult<MedAdministrationLogBaseWithId>> CreateMedAdministrationEntryAsync(
        [FromBody] MedAdministrationLogBase administrationLogBase, CancellationToken cancellationToken)
    {
        return await mediator.Send(new CreateMedAdminLogCommand(administrationLogBase), cancellationToken);
    }

    [HttpGet]
    [Route("{scheduleId}")]
    public async Task<ActionResult<MedAdministrationLogBaseWithId>> GetMedAdministrationEntryAsync(
        [FromRoute] int scheduleId, CancellationToken cancellationToken)
    {
        return await mediator.Send(new GetMedAdminLogCommand(scheduleId), cancellationToken);
    }
}