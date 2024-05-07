using MediatR;
using MedicationTracking.Models;
using Microsoft.AspNetCore.Mvc;

namespace MedicationTracking.Features.MedicineScheduling;

/// <summary>
/// 
/// </summary>
/// <param name="scheduleId"></param>
public class GetScheduleByIdCommand(int scheduleId): IRequest<ActionResult<MedicineSchedulingSingelDto>>
{
    /// <summary>
    /// 
    /// </summary>
    public int ScheduleId { get; set; } = scheduleId;
}