using Data.Models;
using MediatR;
using MedicationTracking.Features.TimeCategory;
using MedicationTracking.Models;
using MedicationTracking.Repository;
using Microsoft.AspNetCore.Mvc;
#pragma warning disable CS0472 // The result of the expression is always the same since a value of this type is never equal to 'null'

namespace MedicationTracking.Features.MedicineScheduling;

/// <summary>
///
/// </summary>
public class EditMedicineScheduleHandler(
    IMedicationTrackingRepository repository,
    IMediator mediator
) : IRequestHandler<EditMedScheduleCommand, ActionResult<MedicineSchedulingSingelDto>>
{
    /// <summary>
    ///
    /// </summary>
    /// <param name="request"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public async Task<ActionResult<MedicineSchedulingSingelDto>> Handle(
        EditMedScheduleCommand request,
        CancellationToken cancellationToken
    )
    {
        var medicineSchedule = (
            await mediator.Send(
                new GetMedScheduleFromDatabaseCommand(
                    new PatientMedRequestDto(
                        request.MedicineScheduleDto.GenericName,
                        request.MedicineScheduleDto.BrandName,
                        request.MedicineScheduleDto.PatientId
                    )
                ),
                cancellationToken
            )
        ).Value;

        if (medicineSchedule == null)
            return new NotFoundObjectResult("Med Schedule not found in the database!");

        var timeCategoryNew = (
            await mediator.Send(
                new GetTimeCategoryIdCommand(request.MedicineScheduleDto.TimeCategory),
                cancellationToken
            )
        ).Value;

        if (timeCategoryNew == null)
            return new NotFoundObjectResult("New time category is not valid!");

        var timeCategoryOld = (
            await mediator.Send(
                new GetTimeCategoryIdCommand(medicineSchedule.TimeCategory!.Description!),
                cancellationToken
            )
        ).Value;

        await repository.AddAsync(
            new ScheduleChangeLog(
                medicineSchedule.ScheduleId,
                timeCategoryOld!.TimeCategoryId,
                timeCategoryNew.TimeCategoryId,
                medicineSchedule.Dosage,
                request.MedicineScheduleDto.Dosage,
                medicineSchedule.Start,
                request.MedicineScheduleDto.Start,
                medicineSchedule.End,
                request.MedicineScheduleDto.End
            ),
            cancellationToken
        );

        medicineSchedule.Dosage = request.MedicineScheduleDto.Dosage;
        medicineSchedule.TimeCategoryId = timeCategoryNew.TimeCategoryId;
        medicineSchedule.Start = request.MedicineScheduleDto.Start;
        medicineSchedule.End = request.MedicineScheduleDto.End;

        await repository.SaveAsync(cancellationToken);

        return new MedicineSchedulingSingelDto(
            medicineSchedule.ScheduleId,
            medicineSchedule.MedicineId,
            medicineSchedule.PatientId,
            timeCategoryNew!.Description!,
            medicineSchedule.Dosage,
            medicineSchedule.Start,
            medicineSchedule.End
        );
    }
}
