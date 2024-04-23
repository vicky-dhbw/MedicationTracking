using MediatR;
using MedicationTracking.Models;
using MedicationTracking.Repository;
using Microsoft.AspNetCore.Mvc;

namespace MedicationTracking.Features.MedicineScheduling;

/// <summary>
/// The handler for get med schedule command
/// </summary>
/// <param name="repository"></param>
/// <param name="mediator"></param>
public class GetMedScheduleHandler(IMedicationTrackingRepository repository, IMediator mediator)
    : IRequestHandler<GetMedScheduleCommand, ActionResult<List<MedicineSchedulingSingelDto>>>
{
    /// <summary>
    /// The handle method of the get med schedule handler
    /// </summary>
    /// <param name="request"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    /// <exception cref="NotImplementedException"></exception>
    public async Task<ActionResult<List<MedicineSchedulingSingelDto>>> Handle(
        GetMedScheduleCommand request,
        CancellationToken cancellationToken
    )
    {
        var medicineScheduleList = (
            await mediator.Send(
                new GetMedScheduleFromDatabaseCommand(
                    new PatientMedRequestDto(
                        request.PatientMedRequestDto.GenericName,
                        request.PatientMedRequestDto.BrandName,
                        request.PatientMedRequestDto.PatientId
                    )
                ),
                cancellationToken
            )
        ).Value;

        if (medicineScheduleList == null)
            return new NotFoundObjectResult("Med Schedule not found in the database!");

        if (medicineScheduleList.Count == 0)
            return new NotFoundObjectResult("No Med Schedule not found in the database!");

        return medicineScheduleList
            .Select(ms => new MedicineSchedulingSingelDto(
                ms.ScheduleId,
                ms.MedicineId,
                ms.PatientId,
                ms.TimeCategory!.Description!,
                ms.Dosage,
                ms.Start,
                ms.End
            ))
            .ToList();
    }
}
