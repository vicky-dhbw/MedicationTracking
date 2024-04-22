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
public class GetAllMedForAGenericNameHandler(IMedicationTrackingRepository repository)
    : IRequestHandler<GetAllMedForAGenericNameCommand, ActionResult<List<MedicineDtoWithId>>>
{
    /// <summary>
    ///
    /// </summary>
    /// <param name="request"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public async Task<ActionResult<List<MedicineDtoWithId>>> Handle(
        GetAllMedForAGenericNameCommand request,
        CancellationToken cancellationToken
    )
    {
        var medicineListWithSameGenericName = await repository.ListAsync(
            new MedicinesByGenericNameSpec(request.GenericName),
            cancellationToken
        );

        // ReSharper disable once ConditionIsAlwaysTrueOrFalseAccordingToNullableAPIContract
        if (medicineListWithSameGenericName.Count == 0)
            return new NotFoundObjectResult("No medicine found for the given generic name!");

        return medicineListWithSameGenericName
            .Select(medicine => (MedicineDtoWithId)medicine)
            .ToList();
    }
}
