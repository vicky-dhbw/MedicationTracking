using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace MedicationTracking.Features.MedicineScheduling;

/// <summary>
/// 
/// </summary>
/// <param name="timeCategoryId"></param>
public class GetTimeCategoryDescriptionCommand(int timeCategoryId): IRequest<ActionResult<string>>
{
    /// <summary>
    /// 
    /// </summary>
    public int TimeCategoryId { get; } = timeCategoryId;
}