using MediatR;
using MedicationTracking.Models;
using Microsoft.AspNetCore.Mvc;

namespace MedicationTracking.Features.Medicine;

/// <summary>
///
/// </summary>
/// <param name="medicine"></param>
public class GetMedByNameCommand(MedicineBase medicine) : IRequest<ActionResult<MedicineDtoWithId>>
{
    /// <summary>
    ///
    /// </summary>
    public MedicineBase Medicine { get; } = medicine;
}
