using MediatR;
using MedicationTracking.Models;

namespace MedicationTracking.Features.Medicine;

public class CreateMedicineCommand(MedicineDto medicineDto) : IRequest<MedicineDto>
{
    public MedicineDto MedicineDto { get; } = medicineDto;
}
