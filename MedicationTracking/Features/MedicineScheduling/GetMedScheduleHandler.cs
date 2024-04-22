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
    : IRequestHandler<GetMedScheduleCommand, ActionResult<MedicineSchedulingSingelDto>>
{
    /// <summary>
    /// The handle method of the get med schedule handler
    /// </summary>
    /// <param name="request"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    /// <exception cref="NotImplementedException"></exception>
    public async Task<ActionResult<MedicineSchedulingSingelDto>> Handle(
        GetMedScheduleCommand request,
        CancellationToken cancellationToken
    )
    {
        var medicineSchedule = (
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

        if (medicineSchedule == null)
            return new NotFoundObjectResult("Med Schedule not found in the database!");

        /*var timeCategoryDescription = (
            await mediator.Send(
                new GetTimeCategoryDescriptionCommand(medicineSchedule.TimeCategoryId),
                cancellationToken
            )
        ).Value;*/

        return new MedicineSchedulingSingelDto(
            medicineSchedule.ScheduleId,
            medicineSchedule.MedicineId,
            medicineSchedule.PatientId,
            medicineSchedule.TimeCategory!.Description!,
            medicineSchedule.Dosage,
            medicineSchedule.Start,
            medicineSchedule.End
        );
    }
}
