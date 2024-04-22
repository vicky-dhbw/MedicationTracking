using Data.Models;
using MediatR;
using MedicationTracking.Features.Medicine;
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
/// <param name="mediator"></param>
public class CreateMedScheduleHandler(IMedicationTrackingRepository repository, IMediator mediator)
    : IRequestHandler<CreateMedScheduleCommand, ActionResult<MedicineSchedulingSingelDto>>
{
    /// <summary>
    /// handles the create medSchedule command
    /// </summary>
    /// <param name="request"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    /// <exception cref="NotImplementedException"></exception>
    public async Task<ActionResult<MedicineSchedulingSingelDto>> Handle(
        CreateMedScheduleCommand request,
        CancellationToken cancellationToken
    )
    {
        var medicineInDb = (
            await mediator.Send(
                new GetMedicineFromDatabaseCommand(
                    new MedicineBase(
                        request.MedicineSchedule.GenericName,
                        request.MedicineSchedule.BrandName
                    )
                ),
                cancellationToken
            )
        ).Value;

        if (medicineInDb == null)
            return new BadRequestObjectResult(
                "Medicine with the generic and brand does not exist!"
            );

        var patient = await repository.FirstOrDefault(
            new PatientByIdSpec(request.MedicineSchedule.PatientId),
            cancellationToken
        );

        // ReSharper disable once ConditionIsAlwaysTrueOrFalseAccordingToNullableAPIContract
        if (patient == null)
            return new BadRequestObjectResult(
                $"Patient with id {request.MedicineSchedule.PatientId} does not exist!"
            );

        var timeCategory = (
            await mediator.Send(
                new GetTimeCategoryIdCommand(request.MedicineSchedule.TimeCategory),
                cancellationToken
            )
        ).Value;

        if (timeCategory == null)
            return new BadRequestObjectResult(
                "Make sure the time is mentioned properly! Try words like: Before Breakfast, After Breakfast, Before Lunch, After Lunch, Evening, Before Dinner, After Dinner, Before Bed.!"
            );

        var medicineSchedule = await repository.AddAsync(
            new MedicationSchedule(
                medicineInDb.MedicineId,
                patient.PatientId,
                timeCategory.TimeCategoryId,
                request.MedicineSchedule.Dosage,
                request.MedicineSchedule.Start,
                request.MedicineSchedule.End
            ),
            cancellationToken
        );

        await repository.SaveAsync(cancellationToken);

        return new MedicineSchedulingSingelDto(
            medicineSchedule.ScheduleId,
            medicineSchedule.MedicineId,
            medicineSchedule.PatientId,
            request.MedicineSchedule.TimeCategory,
            medicineSchedule.Dosage,
            medicineSchedule.Start,
            medicineSchedule.End
        );
    }
}
