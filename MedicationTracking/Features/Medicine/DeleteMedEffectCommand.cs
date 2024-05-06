using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace MedicationTracking.Features.Medicine;

/// <summary>
///
/// </summary>
/// <param name="effectId"></param>
public class DeleteMedEffectCommand(int effectId) : IRequest<ActionResult>
{
    /// <summary>
    ///
    /// </summary>
    public int EffectId { get; } = effectId;
}
