using MediatR;
using MedicationTracking.Repository;
using MedicationTracking.Specifications;
using Microsoft.AspNetCore.Mvc;

namespace MedicationTracking.Features.Medicine;

public class DeleteMedicineHandler(IMedicationTrackingRepository repository)
    : IRequestHandler<DeleteMedicineCommand, ActionResult>
{
    public async Task<ActionResult> Handle(
        DeleteMedicineCommand request,
        CancellationToken cancellationToken
    )
    {
        var medicineToBeDeleted = await repository.FirstOrDefault(
            new MedicineByIdSpec(request.MedicineId),
            cancellationToken
        );

        // ReSharper disable once ConditionIsAlwaysTrueOrFalseAccordingToNullableAPIContract
        if (medicineToBeDeleted == null)
            return new BadRequestResult();
        repository.Remove(medicineToBeDeleted);
        await repository.SaveAsync(cancellationToken);
        return new OkResult();
    }
}
