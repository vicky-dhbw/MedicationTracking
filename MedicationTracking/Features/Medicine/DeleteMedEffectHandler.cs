using MediatR;
using MedicationTracking.Repository;
using MedicationTracking.Specifications;
using Microsoft.AspNetCore.Mvc;

namespace MedicationTracking.Features.Medicine;

/// <summary>
/// 
/// </summary>
/// <param name="repository"></param>
public class DeleteMedEffectHandler(IMedicationTrackingRepository repository) : IRequestHandler<DeleteMedEffectCommand, ActionResult>
{
    /// <summary>
    /// 
    /// </summary>
    /// <param name="request"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public async Task<ActionResult> Handle(DeleteMedEffectCommand request, CancellationToken cancellationToken)
    {
        var medicineEffect =
            await repository.FirstOrDefault(new MedicationEffectByIdSpec(request.EffectId), cancellationToken);

        // ReSharper disable once ConditionIsAlwaysTrueOrFalseAccordingToNullableAPIContract
        if (medicineEffect == null) return new NotFoundObjectResult("Medication Effect not found!");

        repository.Remove(medicineEffect);
        await repository.SaveAsync(cancellationToken);
        return new OkResult();
    }
}