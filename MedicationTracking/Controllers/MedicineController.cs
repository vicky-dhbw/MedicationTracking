using System.ComponentModel.DataAnnotations;
using MediatR;
using MedicationTracking.Features.Medicine;
using MedicationTracking.Models;
using Microsoft.AspNetCore.Mvc;

namespace MedicationTracking.Controllers;

/// <summary>
/// Controller for medicine management
/// </summary>
/// <param name="mediator"></param>
[Route("api/[controller]")]
public class MedicineController(IMediator mediator) : ControllerBase
{
    /// <summary>
    /// mediator to send the commands
    /// </summary>
    private readonly IMediator _mediator = mediator;

    /// <summary>
    /// Create a medicine and save it to database
    /// </summary>
    /// <param name="medicine"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    [HttpPost]
    public async Task<ActionResult<MedicineDto>> CreateMedicineAsync(
        [FromBody] [Required] MedicineDto medicine,
        CancellationToken cancellationToken
    )
    {
        return await _mediator.Send(new CreateMedicineCommand(medicine), cancellationToken);
    }

    /// <summary>
    /// Get Medicine from medicineId
    /// </summary>
    /// <param name="medicineId"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    [HttpGet("{medicineId}")]
    public async Task<ActionResult<MedicineDtoWithId>> GetMedicineAsync(
        [FromRoute] [Required] int medicineId,
        CancellationToken cancellationToken
    )
    {
        return await _mediator.Send(new GetMedicineInfoCommand(medicineId), cancellationToken);
    }

    /// <summary>
    /// Get Medicine from generic name and brand name
    /// </summary>
    /// <param name="genericName"></param>
    /// <param name="brandName"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    [HttpGet]
    public async Task<ActionResult<MedicineDtoWithId>> GetMedicineByNameAsync(
        [FromQuery] [Required] string genericName,
        [FromQuery] [Required] string brandName,
        CancellationToken cancellationToken
    )
    {
        return await _mediator.Send(
            new GetMedByNameCommand(new MedicineBase(genericName, brandName)),
            cancellationToken
        );
    }

    /// <summary>
    /// Update a medicine
    /// </summary>
    /// <param name="medicine"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    [HttpPut]
    [Route("UpdateMedicine")]
    public async Task<ActionResult<MedicineDto>> UpdateMedicineAsync(
        [FromBody] [Required] MedicineDtoWithId medicine,
        CancellationToken cancellationToken
    )
    {
        return await _mediator.Send(new UpdateMedicineCommand(medicine), cancellationToken);
    }

    /// <summary>
    /// Delete a Medicine from the database
    /// </summary>
    /// <param name="medicineId"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    [HttpDelete]
    [Route("{medicineId}")]
    public async Task<ActionResult> DeleteMedicineAsync(
        [FromRoute] [Required] int medicineId,
        CancellationToken cancellationToken
    )
    {
        return await _mediator.Send(new DeleteMedicineCommand(medicineId), cancellationToken);
    }

    /// <summary>
    /// Get all medicines for a generic name
    /// </summary>
    /// <param name="genericName"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    [HttpGet]
    [Route("AllMedsForAGenericName/{genericName}")]
    public async Task<ActionResult<List<MedicineDtoWithId>>> GetMedicineWithSameGenericName(
        [FromRoute] [Required] string genericName,
        CancellationToken cancellationToken
    )
    {
        return await _mediator.Send(
            new GetAllMedForAGenericNameCommand(genericName),
            cancellationToken
        );
    }

    /// <summary>
    /// Add an health effect for a medicine
    /// </summary>
    /// <param name="medicationEffectRequestDto"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    [HttpPost]
    [Route("AddMedEffect")]
    public async Task<ActionResult<MedicationEffectResponseDto>> AddMedicationEffect(
        [FromBody] [Required] MedicationEffectRequestDto medicationEffectRequestDto,
        CancellationToken cancellationToken
    )
    {
        return await _mediator.Send(
            new AddMedicationEffectCommand(medicationEffectRequestDto),
            cancellationToken
        );
    }

    /// <summary>
    /// Get a Medicine with all its health effects
    /// </summary>
    /// <param name="genericName"></param>
    /// <param name="brandName"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    [HttpGet]
    [Route("AllEffectsForMed")]
    public async Task<ActionResult<MedicineDtoWithEffects>> GetAllMedEffectsForMed(
        [FromQuery] [Required] string genericName,
        [FromQuery] [Required] string brandName,
        CancellationToken cancellationToken
    )
    {
        return await _mediator.Send(
            new GetAllMedEffectsCommand(new MedicineBase(genericName, brandName)),
            cancellationToken
        );
    }
}
