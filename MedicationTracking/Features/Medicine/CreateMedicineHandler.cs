using MediatR;
using MedicationTracking.Models;
using MedicationTracking.Repository;
using MedicationTracking.Specifications;
using Microsoft.AspNetCore.Mvc;

namespace MedicationTracking.Features.Medicine;

/// <summary>
/// Create medicine handler
/// </summary>
/// <param name="repository"></param>
public class CreateMedicineHandler(IMedicationTrackingRepository repository)
    : IRequestHandler<CreateMedicineCommand, ActionResult<MedicineDto>>
{
    /// <summary>
    /// Handler method of the handler
    /// </summary>
    /// <param name="request"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public async Task<ActionResult<MedicineDto>> Handle(
        CreateMedicineCommand request,
        CancellationToken cancellationToken
    )
    {
        var medicineInDb = await repository.FirstOrDefault(
            new SameGenericAndBrandNameSpec(request.MedicineDto),
            cancellationToken
        );

        // ReSharper disable once ConditionIsAlwaysTrueOrFalseAccordingToNullableAPIContract
        if (medicineInDb != null)
            return new BadRequestObjectResult(
                "Medicine with the same generic and brand name already exists!"
            );

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
