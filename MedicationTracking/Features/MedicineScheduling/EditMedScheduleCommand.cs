using MediatR;
using MedicationTracking.Models;
using Microsoft.AspNetCore.Mvc;

namespace MedicationTracking.Features.MedicineScheduling;

/// <summary>
///
/// </summary>
/// <param name="medicineScheduleBase"></param>
public class EditMedScheduleCommand(MedicineScheduleBase medicineScheduleBase)
    : IRequest<ActionResult<MedicineSchedulingSingelDto>>
{
    /// <summary>
    ///
    /// </summary>
    public MedicineScheduleBase MedicineScheduleBase { get; } = medicineScheduleBase;
}
