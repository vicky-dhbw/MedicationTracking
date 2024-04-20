using MediatR;
using MedicationTracking.Models;
using MedicationTracking.Repository;
using MedicationTracking.Specifications;

namespace MedicationTracking.Features.Patient;

public class GetPatientByIdHandler(IMedicationTrackingRepository repository): IRequestHandler<GetPatientByIdCommand, PatientDtoWithId>
{
    public async Task<PatientDtoWithId> Handle(GetPatientByIdCommand request, CancellationToken cancellationToken)
    {
        return await repository.FirstOrDefault(new PatientByIdSpec(request.PatientId), cancellationToken);
    }
}