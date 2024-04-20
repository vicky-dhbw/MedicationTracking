using MediatR;
using MedicationTracking.Models;
using MedicationTracking.Repository;
using MedicationTracking.Specifications;
using Microsoft.AspNetCore.Mvc;

namespace MedicationTracking.Features.Patient;

public class GetPatientByIdHandler(IMedicationTrackingRepository repository)
    : IRequestHandler<GetPatientByIdCommand, ActionResult<PatientDtoWithId>>
{
    public async Task<ActionResult<PatientDtoWithId>> Handle(
        GetPatientByIdCommand request,
        CancellationToken cancellationToken
    )
    {
        var patient = await repository.FirstOrDefault(
            new PatientByIdSpec(request.PatientId),
            cancellationToken
        );

        // ReSharper disable once ConditionIsAlwaysTrueOrFalseAccordingToNullableAPIContract
        return patient == null
            ? new NotFoundObjectResult("Patient Not Found!")
            : new PatientDtoWithId(
                patient.PatientId,
                patient.FirstName,
                patient.LastName,
                patient.DateOfBirth,
                patient.Gender,
                patient.RoomNo
            );
    }
}
