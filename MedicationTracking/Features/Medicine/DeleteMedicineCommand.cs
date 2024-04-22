using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace MedicationTracking.Features.Medicine;

/// <summary>
///
/// </summary>
/// <param name="medicineId"></param>
public class DeleteMedicineCommand(int medicineId) : IRequest<ActionResult>
{
    /// <summary>
    ///
    /// </summary>
    public int MedicineId { get; } = medicineId;
}
