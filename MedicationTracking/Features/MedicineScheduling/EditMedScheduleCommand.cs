using MediatR;
using MedicationTracking.Models;
using Microsoft.AspNetCore.Mvc;

namespace MedicationTracking.Features.MedicineScheduling;

/// <summary>
///
/// </summary>
/// <param name="medicineScheduleDto"></param>
public class EditMedScheduleCommand(MedicineScheduleDto medicineScheduleDto)
    : IRequest<ActionResult<MedicineSchedulingSingelDto>>
{
    /// <summary>
    ///
    /// </summary>
    public MedicineScheduleDto MedicineScheduleDto { get; } = medicineScheduleDto;
}
