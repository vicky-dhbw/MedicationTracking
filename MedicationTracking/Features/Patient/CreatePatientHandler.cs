using Data.Models;
using MediatR;
using MedicationTracking.Models;
using MedicationTracking.Repository;

namespace MedicationTracking.Features.Patient;

public class CreatePatientHandler(IMedicationTrackingRepository repository)
    : IRequestHandler<CreatePatientCommand, PatientDto>
{
    public async Task<PatientDto> Handle(
        CreatePatientCommand request,
        CancellationToken cancellationToken
    )
    {
        var patient = await repository.AddAsync(
            new Data.Models.Patient(
                request.Patient.FirstName,
                request.Patient.LastName,
                request.Patient.DateOfBirth,
                request.Patient.Gender,
                request.Patient.RoomNo
            ),
            cancellationToken
        );

        await repository.SaveAsync(cancellationToken);

        return new PatientDto(
            patient.FirstName,
            patient.LastName,
            patient.DateOfBirth,
            patient.Gender,
            patient.RoomNo
        );
    }
}
