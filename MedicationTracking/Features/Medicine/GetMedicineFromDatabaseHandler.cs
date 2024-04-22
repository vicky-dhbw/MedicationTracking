using MediatR;
using MedicationTracking.Repository;
using MedicationTracking.Specifications;
using Microsoft.AspNetCore.Mvc;

namespace MedicationTracking.Features.Medicine;

/// <summary>
///
/// </summary>
/// <param name="repository"></param>
public class GetMedicineFromDatabaseHandler(IMedicationTrackingRepository repository)
    : IRequestHandler<GetMedicineFromDatabaseCommand, ActionResult<Data.Models.Medicine>>
{
    /// <summary>
    ///
    /// </summary>
    /// <param name="request"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public async Task<ActionResult<Data.Models.Medicine>> Handle(
        GetMedicineFromDatabaseCommand request,
        CancellationToken cancellationToken
    )
    {
        var medicineInDb = await repository.FirstOrDefault(
            new SameGenericAndBrandNameSpec(request.MedicineBase),
            cancellationToken
        );

        // ReSharper disable once ConditionIsAlwaysTrueOrFalseAccordingToNullableAPIContract
        if (medicineInDb == null)
            return new BadRequestObjectResult(
                "Medicine with the generic and brand does not exist!"
            );

        return medicineInDb;
    }
}
