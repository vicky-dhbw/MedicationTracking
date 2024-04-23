using MediatR;
using MedicationTracking.Models;
using Microsoft.AspNetCore.Mvc;

namespace MedicationTracking.Features.MedAdministrationLog;

/// <summary>
/// 
/// </summary>
/// <param name="scheduleId"></param>
public class GetMedAdminLogCommand(int scheduleId) : IRequest<ActionResult<MedAdministrationLogBaseWithId>>
{
    /// <summary>
    /// 
    /// </summary>
    public int ScheduleId { get; set; } = scheduleId;
}