using MediatR;
using MedicationTracking.Models;
using Microsoft.AspNetCore.Mvc;

namespace MedicationTracking.Features.Medicine;

/// <summary>
///
/// </summary>
/// <param name="medicineBase"></param>
public class GetAllMedEffectsCommand(MedicineBase medicineBase)
    : IRequest<ActionResult<MedicineDtoWithEffects>>
{
    /// <summary>
    ///
    /// </summary>
    public MedicineBase MedicineBase { get; } = medicineBase;
}
