using MediatR;
using MedicationTracking.Models;
using Microsoft.AspNetCore.Mvc;

namespace MedicationTracking.Features.Medicine;

/// <summary>
///
/// </summary>
/// <param name="medicineDto"></param>
public class CreateMedicineCommand(MedicineDto medicineDto) : IRequest<ActionResult<MedicineDto>>
{
    /// <summary>
    ///
    /// </summary>
    public MedicineDto MedicineDto { get; } = medicineDto;
}
