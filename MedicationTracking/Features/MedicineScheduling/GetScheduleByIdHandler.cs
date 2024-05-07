using MediatR;
using MedicationTracking.Features.TimeCategory;
using MedicationTracking.Models;
using MedicationTracking.Repository;
using MedicationTracking.Specifications;
using Microsoft.AspNetCore.Mvc;

namespace MedicationTracking.Features.MedicineScheduling;

/// <summary>
/// 
/// </summary>
/// <param name="repository"></param>
public class GetScheduleByIdHandler(IMedicationTrackingRepository repository, IMediator mediator) : IRequestHandler<GetScheduleByIdCommand, ActionResult<MedicineSchedulingSingelDto>>
{
    /// <summary>
    /// 
    /// </summary>
    /// <param name="request"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    /// <exception cref="NotImplementedException"></exception>
    public async Task<ActionResult<MedicineSchedulingSingelDto>> Handle(GetScheduleByIdCommand request, CancellationToken cancellationToken)
    {
        var medSchedule =
            await repository.FirstOrDefault(new MedScheduleByIdSpec(request.ScheduleId), cancellationToken);

        
        // ReSharper disable once ConditionIsAlwaysTrueOrFalseAccordingToNullableAPIContract
        if (medSchedule == null) return new NotFoundObjectResult("Schedule not found in the database.");

        var timeCategoryString = (await mediator.Send(new GetTimeCategoryDescriptionCommand(medSchedule.TimeCategoryId),
            cancellationToken)).Value!.Description;

        return new MedicineSchedulingSingelDto(medSchedule.ScheduleId, medSchedule.MedicineId, medSchedule.PatientId,
            timeCategoryString!, medSchedule.Dosage, medSchedule.Start, medSchedule.End);
    }
}