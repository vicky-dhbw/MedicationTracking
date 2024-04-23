using MediatR;
using MedicationTracking.Models;
using Microsoft.AspNetCore.Mvc;

namespace MedicationTracking.Features.Patient;

/// <summary>
/// 
/// </summary>
/// <param name="qrCodeValue"></param>
public class GetPatientByQrCodeCommand(string qrCodeValue) : IRequest<ActionResult<PatientBase>>
{
    /// <summary>
    /// 
    /// </summary>
    public string QrCodeValue { get; set; } = qrCodeValue;
}