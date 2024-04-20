using MediatR;
using MedicationTracking.Models;
using MedicationTracking.Repository;

namespace MedicationTracking.Features.Medicine;

public class CreateMedicineHandler(IMedicationTrackingRepository repository)
    : IRequestHandler<CreateMedicineCommand, MedicineDto>
{
    public async Task<MedicineDto> Handle(
        CreateMedicineCommand request,
        CancellationToken cancellationToken
    )
    {
        var medicine = await repository.AddAsync(
            new Data.Models.Medicine(
                request.MedicineDto.GenericName,
                request.MedicineDto.BrandName,
                request.MedicineDto.Color,
                request.MedicineDto.Form,
                request.MedicineDto.AdministrationMethod
            ),
            cancellationToken
        );
        await repository.SaveAsync(cancellationToken);
        return new MedicineDto(
            medicine.GenericName,
            medicine.BrandName,
            medicine.Color,
            medicine.Form,
            medicine.AdministrationMethod
        );
    }
}
