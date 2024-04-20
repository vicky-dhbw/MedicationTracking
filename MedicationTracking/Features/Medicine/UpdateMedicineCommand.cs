using MediatR;
using MedicationTracking.Models;
using Microsoft.AspNetCore.Mvc;

namespace MedicationTracking.Features.Medicine;

public class UpdateMedicineCommand(MedicineDtoWithId medicineDtoWithId)
    : IRequest<ActionResult<MedicineDto>>
{
    public MedicineDtoWithId MedicineDtoWithId { get; } = medicineDtoWithId;
}
