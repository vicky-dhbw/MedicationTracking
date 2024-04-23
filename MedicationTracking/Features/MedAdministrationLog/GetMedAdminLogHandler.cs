using MediatR;
using MedicationTracking.Models;
using MedicationTracking.Repository;
using MedicationTracking.Specifications;
using Microsoft.AspNetCore.Mvc;

namespace MedicationTracking.Features.MedAdministrationLog;

/// <summary>
/// 
/// </summary>
/// <param name="repository"></param>
public class GetMedAdminLogHandler(IMedicationTrackingRepository repository) : IRequestHandler<GetMedAdminLogCommand, ActionResult<MedAdministrationLogBaseWithId>>
{
    /// <summary>
    /// 
    /// </summary>
    /// <param name="request"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public async Task<ActionResult<MedAdministrationLogBaseWithId>> Handle(GetMedAdminLogCommand request, CancellationToken cancellationToken)
    {
        var medAdminLog =
            await repository.FirstOrDefault(new MedAdminLogByScheduleIdSpec(request.ScheduleId), cancellationToken);

        // ReSharper disable once ConditionIsAlwaysTrueOrFalseAccordingToNullableAPIContract
        if (medAdminLog == null)
            return new NotFoundObjectResult("Medicine Administration Log does not exist for the scheduleId");
        
        return new MedAdministrationLogBaseWithId(medAdminLog.MedLogId, medAdminLog.ScheduleId,
            medAdminLog.MedAdminTime, medAdminLog.MedAdminStatus, medAdminLog.MedAdminNote!);
    }
}