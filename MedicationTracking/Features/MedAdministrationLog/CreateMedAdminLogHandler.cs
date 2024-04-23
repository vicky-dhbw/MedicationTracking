using MediatR;
using MedicationTracking.Models;
using MedicationTracking.Repository;
using Microsoft.AspNetCore.Mvc;

namespace MedicationTracking.Features.MedAdministrationLog;

/// <summary>
///
/// </summary>
/// <param name="repository"></param>
public class CreateMedAdminLogHandler(IMedicationTrackingRepository repository)
    : IRequestHandler<CreateMedAdminLogCommand, ActionResult<MedAdministrationLogBaseWithId>>
{
    /// <summary>
    ///
    /// </summary>
    /// <param name="request"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    /// <exception cref="NotImplementedException"></exception>
    public async Task<ActionResult<MedAdministrationLogBaseWithId>> Handle(
        CreateMedAdminLogCommand request,
        CancellationToken cancellationToken
    )
    {
        var medAdminLog = await repository.AddAsync(
            new Data.Models.MedAdministrationLog(
                request.MedAdministrationLogBaseWithId.ScheduleId,
                DateTime.Now,
                request.MedAdministrationLogBaseWithId.MedAdminStatus,
                request.MedAdministrationLogBaseWithId.MedAdminNote
            ),
            cancellationToken
        );

        await repository.SaveAsync(cancellationToken);

        return new MedAdministrationLogBaseWithId(
            medAdminLog.MedLogId,
            medAdminLog.ScheduleId,
            medAdminLog.MedAdminTime,
            medAdminLog.MedAdminStatus,
            medAdminLog.MedAdminNote!
        );
    }
}
