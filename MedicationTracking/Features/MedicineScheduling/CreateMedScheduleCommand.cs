using MediatR;
using MedicationTracking.Models;
using Microsoft.AspNetCore.Mvc;

namespace MedicationTracking.Features.MedicineScheduling;

/// <summary>
/// 
/// </summary>
public class CreateMedScheduleCommand(MedicineScheduleDto medicineSchedule) : IRequest<ActionResult<MedicineSchedulingSingelDto>>
{
    /// <summary>
    /// The Medicine Schedule passed in the command from the controller
    /// </summary>
    public MedicineScheduleDto MedicineSchedule { get; } = medicineSchedule;
}