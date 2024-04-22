using MediatR;
using MedicationTracking.Models;
using Microsoft.AspNetCore.Mvc;

namespace MedicationTracking.Features.Medicine;

public class CreateMedicineCommand(MedicineDto medicineDto) : IRequest<ActionResult<MedicineDto>>
{
    public MedicineDto MedicineDto { get; } = medicineDto;
}
