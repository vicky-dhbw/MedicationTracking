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
public class GetMedicineInfoHandler(IMedicationTrackingRepository repository)
    : IRequestHandler<GetMedicineInfoCommand, ActionResult<MedicineDtoWithId>>
{
    /// <summary>
    ///
    /// </summary>
    /// <param name="request"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public async Task<ActionResult<MedicineDtoWithId>> Handle(
        GetMedicineInfoCommand request,
        CancellationToken cancellationToken
    )
    {
        var medicine = await repository.FirstOrDefault(
            new MedicineByIdSpec(request.MedicineId),
            cancellationToken
        );

        // ReSharper disable once ConditionIsAlwaysTrueOrFalseAccordingToNullableAPIContract
        return medicine == null
            ? new NotFoundObjectResult("Medicine Not Found!")
            : new MedicineDtoWithId(
                medicine.MedicineId,
                medicine.GenericName,
                medicine.BrandName,
                medicine.Color,
                medicine.Form,
                medicine.AdministrationMethod
            );
    }
}
