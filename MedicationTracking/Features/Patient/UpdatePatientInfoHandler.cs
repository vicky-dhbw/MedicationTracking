using MediatR;
using MedicationTracking.Models;
using MedicationTracking.Repository;
using MedicationTracking.Specifications;
using Microsoft.AspNetCore.Mvc;

namespace MedicationTracking.Features.Patient;

/// <summary>
///
/// </summary>
/// <param name="repository"></param>
public class UpdatePatientInfoHandler(IMedicationTrackingRepository repository)
    : IRequestHandler<UpdatePatientInfoCommand, ActionResult<PatientDto>>
{
    /// <summary>
    /// /
    /// </summary>
    /// <param name="request"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public async Task<ActionResult<PatientDto>> Handle(
        UpdatePatientInfoCommand request,
        CancellationToken cancellationToken
    )
    {
        var patientToBeUpdated = await repository.FirstOrDefault(
            new PatientByIdSpec(request.PatientDtoWithId.PatientId),
            cancellationToken
        );

        // ReSharper disable once ConditionIsAlwaysTrueOrFalseAccordingToNullableAPIContract
        if (patientToBeUpdated == null)
            return new NotFoundObjectResult("Patient Not found!");

        patientToBeUpdated.FirstName = request.PatientDtoWithId.FirstName;
        patientToBeUpdated.LastName = request.PatientDtoWithId.LastName;
        patientToBeUpdated.DateOfBirth = request.PatientDtoWithId.DateOfBirth;
        patientToBeUpdated.Gender = request.PatientDtoWithId.Gender;
        patientToBeUpdated.RoomNo = request.PatientDtoWithId.RoomNo;

        await repository.SaveAsync(cancellationToken);
        return new PatientDto(
            patientToBeUpdated.FirstName,
            patientToBeUpdated.LastName,
            patientToBeUpdated.DateOfBirth,
            patientToBeUpdated.Gender,
            patientToBeUpdated.RoomNo
        );
    }
}
