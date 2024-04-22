using MediatR;
using MedicationTracking.Models;
using Microsoft.AspNetCore.Mvc;

namespace MedicationTracking.Features.Medicine;

public class GetAllMedEffectsCommand(MedicineBase medicineBase)
    : IRequest<ActionResult<MedicineDtoWithEffects>>
{
    public MedicineBase MedicineBase { get; } = medicineBase;
}
