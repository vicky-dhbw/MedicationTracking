using MediatR;
using MedicationTracking.Models;
using Microsoft.AspNetCore.Mvc;

namespace MedicationTracking.Features.Medicine;

/// <summary>
///
/// </summary>
/// <param name="medicineDtoWithId"></param>
public class UpdateMedicineCommand(MedicineDtoWithId medicineDtoWithId)
    : IRequest<ActionResult<MedicineDto>>
{
    /// <summary>
    ///
    /// </summary>
    public MedicineDtoWithId MedicineDtoWithId { get; } = medicineDtoWithId;
}
