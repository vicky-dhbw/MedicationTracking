using MediatR;
using MedicationTracking.Models;
using MedicationTracking.Repository;
using MedicationTracking.Specifications;
using Microsoft.AspNetCore.Mvc;

namespace MedicationTracking.Features.Medicine;

public class UpdateMedicineHandler(IMedicationTrackingRepository repository)
    : IRequestHandler<UpdateMedicineCommand, ActionResult<MedicineDto>>
{
    public async Task<ActionResult<MedicineDto>> Handle(
        UpdateMedicineCommand request,
        CancellationToken cancellationToken
    )
    {
        var medicineToBeUpdated = await repository.FirstOrDefault(
            new MedicineByIdSpec(request.MedicineDtoWithId.MedicineId),
            cancellationToken
        );

        // ReSharper disable once ConditionIsAlwaysTrueOrFalseAccordingToNullableAPIContract
        if (medicineToBeUpdated == null)
            return new NotFoundObjectResult("Medicine Not Found!");

        medicineToBeUpdated.GenericName = request.MedicineDtoWithId.GenericName;
        medicineToBeUpdated.BrandName = request.MedicineDtoWithId.BrandName;
        medicineToBeUpdated.Color = request.MedicineDtoWithId.Color;
        medicineToBeUpdated.Form = request.MedicineDtoWithId.Form;
        medicineToBeUpdated.AdministrationMethod = request.MedicineDtoWithId.AdministrationMethod;

        await repository.SaveAsync(cancellationToken);

        return new MedicineDto(
            medicineToBeUpdated.GenericName,
            medicineToBeUpdated.BrandName,
            medicineToBeUpdated.Color,
            medicineToBeUpdated.Form,
            medicineToBeUpdated.AdministrationMethod
        );
    }
}
