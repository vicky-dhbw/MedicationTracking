using Data.Models;
using MediatR;
using MedicationTracking.Features.Medicine;
using MedicationTracking.Features.Patient;
using MedicationTracking.Models;
using MedicationTracking.Repository;
using MedicationTracking.Specifications;
using Microsoft.AspNetCore.Mvc;

namespace MedicationTracking.Features.MedicineScheduling;

/// <summary>
///
/// </summary>
/// <param name="repository"></param>
public class GetMedScheduleFromDatabaseHandler(
    IMedicationTrackingRepository repository,
    IMediator mediator
) : IRequestHandler<GetMedScheduleFromDatabaseCommand, ActionResult<MedicationSchedule>>
{
    /// <summary>
    ///
    /// </summary>
    /// <param name="request"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    /// <exception cref="NotImplementedException"></exception>
    public async Task<ActionResult<MedicationSchedule>> Handle(
        GetMedScheduleFromDatabaseCommand request,
        CancellationToken cancellationToken
    )
    {
        var medicineInDb = (
            await mediator.Send(
                new GetMedByNameCommand(
                    new MedicineBase(
                        request.PatientMedRequestDto.GenericName,
                        request.PatientMedRequestDto.BrandName
                    )
                ),
                cancellationToken
            )
        ).Value;

        if (medicineInDb == null)
            return new NotFoundObjectResult(
                "No such medicine with the given generic name and brand name exits in the database!"
            );

        var patientInDb = (
            await mediator.Send(
                new GetPatientByIdCommand(request.PatientMedRequestDto.PatientId),
                cancellationToken
            )
        ).Value;

        if (patientInDb == null)
            return new NotFoundObjectResult(
                "No such patient with the given PatientId exists in the database!"
            );

        var medicineSchedule = await repository.FirstOrDefault(
            new MedScheduleByPatientAndMedSpec(patientInDb.PatientId, medicineInDb.MedicineId),
            cancellationToken
        );

        return medicineSchedule;
    }
}
