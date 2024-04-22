using MediatR;
using MedicationTracking.Models;
using Microsoft.AspNetCore.Mvc;

namespace MedicationTracking.Features.Medicine;

/// <summary>
///
/// </summary>
/// <param name="medicationEffect"></param>
public class AddMedicationEffectCommand(MedicationEffectRequestDto medicationEffect)
    : IRequest<ActionResult<MedicationEffectResponseDto>>
{
    /// <summary>
    ///
    /// </summary>
    public MedicationEffectRequestDto MedicationEffect { get; } = medicationEffect;
}
