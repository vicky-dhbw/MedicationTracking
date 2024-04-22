using MediatR;
using MedicationTracking.Repository;
using MedicationTracking.Specifications;
using Microsoft.AspNetCore.Mvc;

namespace MedicationTracking.Features.MedicineScheduling;

/// <summary>
/// Handler to get the time category id from time category description
/// </summary>
/// <param name="repository"></param>
public class GetTimeCategoryIdHandler(IMedicationTrackingRepository repository) : IRequestHandler<GetTimeCategoryIdCommand, ActionResult<int>>
{
    /// <summary>
    /// 
    /// </summary>
    /// <param name="request"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    /// <exception cref="NotImplementedException"></exception>
    public async Task<ActionResult<int>> Handle(GetTimeCategoryIdCommand request, CancellationToken cancellationToken)
    {
        var timeCategoryId =
            await repository.FirstOrDefault(new TimeCategoryByDescriptionSpec(request.TimeCategoryDescription),
                cancellationToken);
        
        // ReSharper disable once ConditionIsAlwaysTrueOrFalseAccordingToNullableAPIContract
        if(timeCategoryId == null) return new BadRequestObjectResult(
            "Make sure the time is mentioned properly! Try words like: Before Breakfast, After Breakfast, Before Lunch, After Lunch, Evening, Before Dinner, After Dinner, Before Bed.!"
        );

        return timeCategoryId.TimeCategoryId;
    }
}