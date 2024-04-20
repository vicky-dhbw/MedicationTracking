using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace MedicationTracking.Features.Medicine;

public class DeleteMedicineCommand(int medicineId) : IRequest<ActionResult>
{
    public int MedicineId { get; } = medicineId;
}
