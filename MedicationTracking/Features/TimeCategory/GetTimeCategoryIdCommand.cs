using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace MedicationTracking.Features.TimeCategory;

/// <summary>
///
/// </summary>
/// <param name="timeCategoryDescription"></param>
public class GetTimeCategoryIdCommand(string timeCategoryDescription)
    : IRequest<ActionResult<Data.Models.TimeCategory>>
{
    /// <summary>
    ///
    /// </summary>
    public string TimeCategoryDescription { get; } = timeCategoryDescription;
}
