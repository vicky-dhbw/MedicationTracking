using MediatR;
using MedicationTracking.Models;
using MedicationTracking.Repository;
using MedicationTracking.Specifications;
using Microsoft.AspNetCore.Mvc;

namespace MedicationTracking.Features.Medicine;

/// <summary>
/// 
/// </summary>
/// <param name="repository"></param>
public class GetMedByNameHandler(IMedicationTrackingRepository repository) : IRequestHandler<GetMedByNameCommand, ActionResult<MedicineDtoWithId>>
{
    /// <summary>
    /// 
    /// </summary>
    /// <param name="request"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public async Task<ActionResult<MedicineDtoWithId>> Handle(GetMedByNameCommand request, CancellationToken cancellationToken)
    {
        var medicineInDb = await repository.FirstOrDefault(
            new SameGenericAndBrandNameSpec(request.Medicine),
            cancellationToken
        );

        // ReSharper disable once ConditionIsAlwaysTrueOrFalseAccordingToNullableAPIContract
        if (medicineInDb == null)
            return new BadRequestObjectResult(
                "Medicine with the generic and brand does not exist!"
            );

        return new MedicineDtoWithId(medicineInDb.MedicineId, medicineInDb.GenericName, medicineInDb.BrandName,
            medicineInDb.Color, medicineInDb.Form, medicineInDb.AdministrationMethod);
    }
}