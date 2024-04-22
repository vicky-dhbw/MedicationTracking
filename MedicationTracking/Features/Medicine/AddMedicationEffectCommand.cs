using MediatR;
using MedicationTracking.Models;
using Microsoft.AspNetCore.Mvc;

namespace MedicationTracking.Features.Medicine;

public class AddMedicationEffectCommand(MedicationEffectRequestDto medicationEffect)
    : IRequest<ActionResult<MedicationEffectResponseDto>>
{
    public MedicationEffectRequestDto MedicationEffect { get; } = medicationEffect;
}
