using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace MedicationTracking.Features.TimeCategory;

/// <summary>
///
/// </summary>
/// <param name="timeCategoryId"></param>
public class GetTimeCategoryDescriptionCommand(int timeCategoryId)
    : IRequest<ActionResult<Data.Models.TimeCategory>>
{
    /// <summary>
    ///
    /// </summary>
    public int TimeCategoryId { get; } = timeCategoryId;
}
