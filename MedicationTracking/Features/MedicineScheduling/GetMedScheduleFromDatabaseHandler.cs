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
) : IRequestHandler<GetMedScheduleFromDatabaseCommand, ActionResult<List<MedicationSchedule>>>
{
    /// <summary>
    ///
    /// </summary>
    /// <param name="request"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    /// <exception cref="NotImplementedException"></exception>
    public async Task<ActionResult<List<MedicationSchedule>>> Handle(
        GetMedScheduleFromDatabaseCommand request,
        CancellationToken cancellationToken
    )
    {
        var medicineInDb = await repository.FirstOrDefault(
            new SameGenericAndBrandNameSpec(
                new MedicineBase(
                    request.PatientMedRequestDto.GenericName,
                    request.PatientMedRequestDto.BrandName
                )
            ),
            cancellationToken
        );

        // ReSharper disable once ConditionIsAlwaysTrueOrFalseAccordingToNullableAPIContract
        if (medicineInDb == null)
            return new NotFoundObjectResult(
                "No such medicine with the given generic name and brand name exits in the database!"
            );

        var patientInDb = await repository.FirstOrDefault(
            new PatientByIdSpec(request.PatientMedRequestDto.PatientId),
            cancellationToken
        );

        // ReSharper disable once ConditionIsAlwaysTrueOrFalseAccordingToNullableAPIContract
        if (patientInDb == null)
            return new NotFoundObjectResult(
                "No such patient with the given PatientId exists in the database!"
            );

        var medicineSchedule = await repository.ListAsync(
            new MedScheduleByPatientAndMedSpec(patientInDb.PatientId, medicineInDb.MedicineId),
            cancellationToken
        );

        return medicineSchedule.ToList();
    }
}
