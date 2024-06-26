using Data.Models;
using MediatR;
using MedicationTracking.Models;
using MedicationTracking.Repository;

namespace MedicationTracking.Features.Patient;

/// <summary>
///
/// </summary>
/// <param name="repository"></param>
public class CreatePatientHandler(IMedicationTrackingRepository repository)
    : IRequestHandler<CreatePatientCommand, PatientDtoWithId>
{
    /// <summary>
    ///
    /// </summary>
    /// <param name="request"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public async Task<PatientDtoWithId> Handle(
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

        var qrCode = await repository.AddAsync(
            new QrCode { Patient = patient, PatientId = patient.PatientId },
            cancellationToken
        );

        await repository.SaveAsync(cancellationToken);

        return new PatientDtoWithId(
            patient.PatientId,
            patient.FirstName,
            patient.LastName,
            patient.DateOfBirth,
            patient.Gender,
            patient.RoomNo
        );
    }
}
