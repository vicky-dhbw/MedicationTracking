using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace MedicationTracking.Features.MedicineScheduling;

/// <summary>
///
/// </summary>
/// <param name="scheduleId"></param>
public class DeleteMedScheduleCommand(int scheduleId) : IRequest<ActionResult>
{
    /// <summary>
    ///
    /// </summary>
    public int ScheduleId { get; set; } = scheduleId;
}
