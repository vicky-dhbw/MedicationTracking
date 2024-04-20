using MediatR;
using MedicationTracking.Models;
using Microsoft.AspNetCore.Mvc;

namespace MedicationTracking.Features.Medicine;

public class GetMedicineInfoCommand(int medicineId) : IRequest<ActionResult<MedicineDtoWithId>>
{
    public int MedicineId { get; } = medicineId;
}
