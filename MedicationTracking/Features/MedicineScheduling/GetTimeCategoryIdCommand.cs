using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace MedicationTracking.Features.MedicineScheduling;

/// <summary>
/// 
/// </summary>
/// <param name="timeCategoryDescription"></param>
public class GetTimeCategoryIdCommand(string timeCategoryDescription) : IRequest<ActionResult<int>>
{
    /// <summary>
    /// 
    /// </summary>
    public string TimeCategoryDescription { get; } = timeCategoryDescription;
}