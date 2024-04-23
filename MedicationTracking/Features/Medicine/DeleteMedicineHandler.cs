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
public class DeleteMedicineHandler(IMedicationTrackingRepository repository)
    : IRequestHandler<DeleteMedicineCommand, ActionResult>
{
    /// <summary>
    ///
    /// </summary>
    /// <param name="request"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public async Task<ActionResult> Handle(
        DeleteMedicineCommand request,
        CancellationToken cancellationToken
    )
    {
        var medicineToBeDeleted = await repository.FirstOrDefault(
            new SameGenericAndBrandNameSpec(
                new MedicineBase(request.GenericName, request.BrandName)
            ),
            cancellationToken
        );

        // ReSharper disable once ConditionIsAlwaysTrueOrFalseAccordingToNullableAPIContract
        if (medicineToBeDeleted == null)
            return new BadRequestResult();

        var medicineSchedulesForMedicine = (
            await repository.ListAsync(
                new AllSchdulesForMedicineIdSpec(medicineToBeDeleted.MedicineId),
                cancellationToken
            )
        ).ToList();

        if (medicineSchedulesForMedicine.Count != 0)
            return new BadRequestObjectResult(
                "Medicine is scheduled for some patients, therefore cannot be deleted!"
            );

        repository.Remove(medicineToBeDeleted);
        await repository.SaveAsync(cancellationToken);
        return new OkResult();
    }
}
