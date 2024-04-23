using MediatR;
using MedicationTracking.Models;
using MedicationTracking.Repository;
using MedicationTracking.Specifications;

namespace MedicationTracking.Features.Patient;

/// <summary>
///
/// </summary>
/// <param name="repository"></param>
public class GetAllPatientsHandler(IMedicationTrackingRepository repository)
    : IRequestHandler<GetAllPatientsCommand, List<PatientDtoWithId>>
{
    /// <summary>
    ///
    /// </summary>
    /// <param name="request"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    /// <exception cref="NotImplementedException"></exception>
    public async Task<List<PatientDtoWithId>> Handle(
        GetAllPatientsCommand request,
        CancellationToken cancellationToken
    )
    {
        var patients = (
            await repository.ListAsync(new AllPatientsSpecs(), cancellationToken)
        ).ToList();

        return patients
            .Select(p => new PatientDtoWithId(
                p.PatientId,
                p.FirstName,
                p.LastName,
                p.DateOfBirth,
                p.Gender,
                p.RoomNo
            ))
            .ToList();
    }
}
