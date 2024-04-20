using MediatR;
using MedicationTracking.Repository;
using MedicationTracking.Specifications;
using Microsoft.AspNetCore.Mvc;

namespace MedicationTracking.Features.Patient;

public class DeletePatientHandler(IMedicationTrackingRepository repository)
    : IRequestHandler<DeletePatientCommand, ActionResult>
{
    public async Task<ActionResult> Handle(
        DeletePatientCommand request,
        CancellationToken cancellationToken
    )
    {
        var patientToBeDeleted = await repository.FirstOrDefault(
            new PatientByIdSpec(request.PatientId),
            cancellationToken
        );

        // ReSharper disable once ConditionIsAlwaysTrueOrFalseAccordingToNullableAPIContract
        if (patientToBeDeleted == null)
            return new BadRequestResult();
        repository.Remove(patientToBeDeleted);
        await repository.SaveAsync(cancellationToken);
        return new OkResult();
    }
}
