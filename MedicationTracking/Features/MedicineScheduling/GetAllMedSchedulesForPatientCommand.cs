using MediatR;
using MedicationTracking.Models;
using Microsoft.AspNetCore.Mvc;

namespace MedicationTracking.Features.MedicineScheduling;

/// <summary>
/// 
/// </summary>
/// <param name="qRcode"></param>
public class GetAllMedSchedulesForPatientCommand(string  qRcode)
    : IRequest<ActionResult<AllMedSchedulesDto>>
{
    /// <summary>
    ///
    /// </summary>
    public string QrCode { get; set; } = qRcode;
}
