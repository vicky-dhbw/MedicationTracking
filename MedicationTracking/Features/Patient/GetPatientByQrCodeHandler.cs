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
public class GetPatientByQrCodeHandler(IMedicationTrackingRepository repository) : IRequestHandler<GetPatientByQrCodeCommand, ActionResult<PatientBase>>
{
    /// <summary>
    /// 
    /// </summary>
    /// <param name="request"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public async Task<ActionResult<PatientBase>> Handle(GetPatientByQrCodeCommand request, CancellationToken cancellationToken)
    {
        var qrCode =
            await repository.FirstOrDefault(new PatientByQrCodeValueSpec(request.QrCodeValue), cancellationToken);

        // ReSharper disable once ConditionIsAlwaysTrueOrFalseAccordingToNullableAPIContract
        if (qrCode == null)
            return new NotFoundObjectResult($"No QrCode code with value {request.QrCodeValue} exists in the database!");
        
        return new PatientBase(qrCode.Patient.PatientId, qrCode.Patient.FirstName, qrCode.Patient.LastName,
            qrCode.Patient.Gender, qrCode.Patient.RoomNo);
    }
}