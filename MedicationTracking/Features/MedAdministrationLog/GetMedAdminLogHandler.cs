using MediatR;
using MedicationTracking.Models;
using MedicationTracking.Repository;
using MedicationTracking.Specifications;
using MedicationTracking.Utility;
using Microsoft.AspNetCore.Mvc;

namespace MedicationTracking.Features.MedAdministrationLog;

/// <summary>
///
/// </summary>
/// <param name="repository"></param>
public class GetMedAdminLogHandler(
    IMedicationTrackingRepository repository,
    TimeCategoryService timeCategoryService
) : IRequestHandler<GetMedAdminLogCommand, ActionResult<MedAdministrationLogBaseWithId>>
{
    /// <summary>
    ///
    /// </summary>
    /// <param name="request"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public async Task<ActionResult<MedAdministrationLogBaseWithId>> Handle(
        GetMedAdminLogCommand request,
        CancellationToken cancellationToken
    )
    {
        var medicationSchedule = await repository.FirstOrDefault(
            new MedScheduleByIdSpec(request.ScheduleId),
            cancellationToken
        );

        // ReSharper disable once ConditionIsAlwaysTrueOrFalseAccordingToNullableAPIContract
        if (medicationSchedule == null)
            return new NotFoundObjectResult("Schedule id is invalid");

        var medAdminLog = await repository.FirstOrDefault(
            new MedAdminLogByScheduleIdSpec(request.ScheduleId),
            cancellationToken
        );

        // ReSharper disable once ConditionIsAlwaysTrueOrFalseAccordingToNullableAPIContract

        if (medAdminLog == null)
        {
            // ReSharper disable once ConditionIsAlwaysTrueOrFalseAccordingToNullableAPIContract
            if (timeCategoryService.GetTimeCategory() != null)
            {
                if (
                    timeCategoryService.GetTimeCategory().TimeCategoryId
                    > medicationSchedule.TimeCategoryId
                )
                {
                    return await PersistSkippedLogs(request.ScheduleId, cancellationToken);
                }

                if (
                    timeCategoryService.GetTimeCategory().TimeCategoryId
                    <= medicationSchedule.TimeCategoryId
                )
                {
                    return ReturnPendingMedication(request.ScheduleId);
                }
            }
            else
            {
                if (DateTime.Now.Hour >= 23)
                {
                    return await PersistSkippedLogs(request.ScheduleId, cancellationToken);
                }
                if (DateTime.Now.Hour >= 14 && DateTime.Now.Hour < 17)
                {
                    if (medicationSchedule.TimeCategoryId < 4)
                    {
                        return await PersistSkippedLogs(request.ScheduleId, cancellationToken);
                    }

                    if (medicationSchedule.TimeCategoryId >= 5)
                    {
                        return ReturnPendingMedication(request.ScheduleId);
                    }
                }

                if (DateTime.Now.Hour >= 0 && DateTime.Now.Hour < 5)
                {
                    return ReturnPendingMedication(request.ScheduleId);
                }
            }
        }

        return new MedAdministrationLogBaseWithId(
            medAdminLog!.MedLogId,
            medAdminLog.ScheduleId,
            medAdminLog.MedAdminTime,
            medAdminLog.MedAdminStatus,
            medAdminLog.MedAdminNote!
        );
    }

    private async Task<MedAdministrationLogBaseWithId> PersistSkippedLogs(
        int scheduleId,
        CancellationToken cancellationToken
    )
    {
        var newMedAdminLog = await repository.AddAsync(
            new Data.Models.MedAdministrationLog(scheduleId, DateTime.Now, -1, "skipped"),
            cancellationToken
        );

        await repository.SaveAsync(cancellationToken);
        return new MedAdministrationLogBaseWithId(
            newMedAdminLog.MedLogId,
            newMedAdminLog.ScheduleId,
            newMedAdminLog.MedAdminTime,
            newMedAdminLog.MedAdminStatus,
            newMedAdminLog.MedAdminNote!
        );
    }

    private MedAdministrationLogBaseWithId ReturnPendingMedication(int scheduleId)
    {
        return new MedAdministrationLogBaseWithId(0, scheduleId, DateTime.Today, 0, "pending");
    }
}
