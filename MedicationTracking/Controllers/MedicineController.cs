using MediatR;
using MedicationTracking.Features.Medicine;
using MedicationTracking.Models;
using Microsoft.AspNetCore.Mvc;

namespace MedicationTracking.Controllers;

[Route("api/[controller]")]
public class MedicineController(IMediator mediator) : ControllerBase
{
    protected readonly IMediator _mediator = mediator;

    [HttpPost]
    public async Task<ActionResult<MedicineDto>> CreateMedicineAsync(
        [FromBody] MedicineDto medicine,
        CancellationToken cancellationToken
    )
    {
        return await _mediator.Send(new CreateMedicineCommand(medicine), cancellationToken);
    }

    [HttpGet("{medicineId}")]
    public async Task<ActionResult<MedicineDtoWithId>> GetMedicineAsync(
        [FromRoute] int medicineId,
        CancellationToken cancellationToken
    )
    {
        return await _mediator.Send(new GetMedicineInfoCommand(medicineId), cancellationToken);
    }

    [HttpPut]
    [Route("UpdateMedicine")]
    public async Task<ActionResult<MedicineDto>> UpdateMedicineAsync(
        [FromBody] MedicineDtoWithId medicine,
        CancellationToken cancellationToken
    )
    {
        return await _mediator.Send(new UpdateMedicineCommand(medicine), cancellationToken);
    }

    [HttpDelete]
    [Route("{medicineId}")]
    public async Task<ActionResult> DeleteMedicineAsync(
        [FromRoute] int medicineId,
        CancellationToken cancellationToken
    )
    {
        return await _mediator.Send(new DeleteMedicineCommand(medicineId), cancellationToken);
    }

    [HttpGet]
    [Route("MedsForAGenericName/{genericName}")]
    public async Task<ActionResult<List<MedicineDtoWithId>>> GetMedicineWithSameGenericName(
        [FromRoute] string genericName,
        CancellationToken cancellationToken
    )
    {
        return await _mediator.Send(
            new GetAllMedForAGenericNameCommand(genericName),
            cancellationToken
        );
    }
}
