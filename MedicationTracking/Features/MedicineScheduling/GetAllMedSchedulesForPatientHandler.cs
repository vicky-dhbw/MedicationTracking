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
public class GetAllMedSchedulesForPatientHandler(
    IMediator mediator,
    IMedicationTrackingRepository repository
) : IRequestHandler<GetAllMedSchedulesForPatientCommand, ActionResult<AllMedSchedulesDto>>
{
    /// <summary>
    ///
    /// </summary>
    /// <param name="request"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public async Task<ActionResult<AllMedSchedulesDto>> Handle(
        GetAllMedSchedulesForPatientCommand request,
        CancellationToken cancellationToken
    )
    {
        var qrCode = await repository.FirstOrDefault(
            new PatientByQrCodeValueSpec(request.QrCode), cancellationToken);

        // ReSharper disable once ConditionIsAlwaysTrueOrFalseAccordingToNullableAPIContract
        if (qrCode == null)
            return new NotFoundObjectResult(
                $"No Patient with qrCode value {request.QrCode} exists in the database!"
            );

        var patient = await repository.FirstOrDefault(new PatientByIdSpec(qrCode.PatientId), cancellationToken);

        var medicineSchedules = await repository.ListAsync(
            new MedScheduleByPatientIdSpec(qrCode.PatientId),
            cancellationToken
        );

        var medInfoScheduleInfos = new List<MedInfoScheduleInfoBase>();

        foreach (var medicineSchedule in medicineSchedules)
        {
            var medicine = await repository.FirstOrDefault(
                new MedicineByIdSpec(medicineSchedule.MedicineId),
                cancellationToken
            );

            medInfoScheduleInfos.Add(
                new MedInfoScheduleInfoBase
                {
                    MedicineDto = new MedicineDto(
                        medicine.GenericName,
                        medicine.BrandName,
                        medicine.Color,
                        medicine.Form,
                        medicine.AdministrationMethod
                    ),
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

        return new AllMedSchedulesDto
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
