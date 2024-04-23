using MediatR;
using MedicationTracking.Models;
using MedicationTracking.Repository;
using MedicationTracking.Specifications;
using Microsoft.AspNetCore.Mvc;

namespace MedicationTracking.Features.MedicineScheduling;

/// <summary>
///
/// </summary>
/// <param name="mediator"></param>
/// <param name="repository"></param>
public class GetAllMedsForPatientHandler(
    IMediator mediator,
    IMedicationTrackingRepository repository
) : IRequestHandler<GetAllMedsForPatientCommand, ActionResult<MedicineSchedulingMultipleDto>>
{
    /// <summary>
    ///
    /// </summary>
    /// <param name="request"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public async Task<ActionResult<MedicineSchedulingMultipleDto>> Handle(
        GetAllMedsForPatientCommand request,
        CancellationToken cancellationToken
    )
    {
        var patient = await repository.FirstOrDefault(
            new PatientByIdSpec(request.PatientId),
            cancellationToken
        );

        // ReSharper disable once ConditionIsAlwaysTrueOrFalseAccordingToNullableAPIContract
        if (patient == null)
            return new NotFoundObjectResult(
                $"No Patient with id {request.PatientId} exists in the database!"
            );

        var medicineSchedules = (
            await repository.ListAsync(
                new MedScheduleByPatientIdSpec(patient.PatientId),
                cancellationToken
            )
        ).ToList();

        var medInfoScheduleInfos = new List<MedInfoScheduleInfo>();

        foreach (var medicineSchedule in medicineSchedules)
        {
            var medicine = await repository.FirstOrDefault(
                new MedicineByIdSpec(medicineSchedule.MedicineId),
                cancellationToken
            );

            medInfoScheduleInfos.Add(
                new MedInfoScheduleInfo
                {
                    MedicineBase = new MedicineBase(medicine.GenericName, medicine.BrandName),
                    MedicineScheduleBase = new MedicineScheduleBase(
                        medicineSchedule.ScheduleId,
                        medicineSchedule.MedicineId,
                        medicineSchedule.TimeCategory!.Description!,
                        medicineSchedule.Dosage,
                        medicineSchedule.Start,
                        medicineSchedule.End
                    )
                }
            );
        }

        return new MedicineSchedulingMultipleDto
        {
            MedicineSchedules = medInfoScheduleInfos,
            Patient = new PatientBase(
                patient.PatientId,
                patient.FirstName,
                patient.LastName,
                patient.Gender,
                patient.RoomNo
            )
        };
    }
}
