using MediatR;
using MedicationTracking.Models;
using Microsoft.AspNetCore.Mvc;

namespace MedicationTracking.Features.Medicine;

public class GetMedByNameCommand(MedicineBase medicine) : IRequest<ActionResult<MedicineDtoWithId>>
{
    public MedicineBase Medicine { get; } = medicine;
}