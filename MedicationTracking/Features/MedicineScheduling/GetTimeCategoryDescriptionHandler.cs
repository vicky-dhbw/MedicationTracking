using MediatR;
using MedicationTracking.Repository;
using MedicationTracking.Specifications;
using Microsoft.AspNetCore.Mvc;

namespace MedicationTracking.Features.MedicineScheduling;

/// <summary>
/// 
/// </summary>
/// <param name="repository"></param>
public class GetTimeCategoryDescriptionHandler(IMedicationTrackingRepository repository) : IRequestHandler<GetTimeCategoryDescriptionCommand, ActionResult<string>>
{
    /// <summary>
    /// 
    /// </summary>
    /// <param name="request"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    /// <exception cref="NotImplementedException"></exception>
    public async Task<ActionResult<string>> Handle(GetTimeCategoryDescriptionCommand request, CancellationToken cancellationToken)
    {
        var timeCategory =
            await repository.FirstOrDefault(new GetTimeCategoryByIdSpec(request.TimeCategoryId), cancellationToken);

        // ReSharper disable once ConditionIsAlwaysTrueOrFalseAccordingToNullableAPIContract
        if (timeCategory == null) return new NotFoundObjectResult("Time category not found in database!");
        
        return timeCategory.Description!;
    }
}