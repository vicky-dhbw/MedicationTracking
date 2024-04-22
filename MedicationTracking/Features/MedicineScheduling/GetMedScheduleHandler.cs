using MediatR;
using MedicationTracking.Features.Medicine;
using MedicationTracking.Features.Patient;
using MedicationTracking.Models;
using MedicationTracking.Repository;
using MedicationTracking.Specifications;
using Microsoft.AspNetCore.Mvc;

namespace MedicationTracking.Features.MedicineScheduling;

/// <summary>
/// The handler for get med schedule command
/// </summary>
/// <param name="repository"></param>
/// <param name="mediator"></param>
public class GetMedScheduleHandler(IMedicationTrackingRepository repository, IMediator mediator) : IRequestHandler<GetMedScheduleCommand, ActionResult<MedicineSchedulingSingelDto>>
{
    /// <summary>
    /// The handle method of the get med schedule handler
    /// </summary>
    /// <param name="request"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    /// <exception cref="NotImplementedException"></exception>
    public async Task<ActionResult<MedicineSchedulingSingelDto>> Handle(GetMedScheduleCommand request, CancellationToken cancellationToken)
    {
        var medicineInDb =
            (await mediator.Send(
                new GetMedByNameCommand(new MedicineBase(request.PatientMedRequestDto.GenericName,
                    request.PatientMedRequestDto.BrandName)), cancellationToken)).Value;

        if (medicineInDb == null)
            return new NotFoundObjectResult(
                "No such medicine with the given generic name and brand name exits in the database!");

        var patientInDb = (await mediator.Send(new GetPatientByIdCommand(request.PatientMedRequestDto.PatientId),
            cancellationToken)).Value;

        if (patientInDb == null)
            return new NotFoundObjectResult("No such patient with the given PatientId exists in the database!");

        var medicineSchedule = await repository.FirstOrDefault(
            new MedScheduleByPatientAndMedSpec(patientInDb.PatientId, medicineInDb.MedicineId), cancellationToken);

        var timeCategoryDescription =
            (await mediator.Send(new GetTimeCategoryDescriptionCommand(medicineSchedule.TimeCategoryId),
                cancellationToken)).Value;

        return new MedicineSchedulingSingelDto(medicineSchedule.ScheduleId, medicineSchedule.MedicineId,
            medicineSchedule.PatientId, timeCategoryDescription!, medicineSchedule.Dosage, medicineSchedule.Start,
            medicineSchedule.End);

    }
}