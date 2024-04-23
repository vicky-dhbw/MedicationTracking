using MediatR;
using MedicationTracking.Models;
using Microsoft.AspNetCore.Mvc;

namespace MedicationTracking.Features.MedicineScheduling;

/// <summary>
///
/// </summary>
/// <param name="patinetId"></param>
public class GetAllMedsForPatientCommand(int patinetId)
    : IRequest<ActionResult<MedicineSchedulingMultipleDto>>
{
    /// <summary>
    ///
    /// </summary>
    public int PatientId { get; set; } = patinetId;
}
