using MediatR;
using MedicationTracking.Models;
using Microsoft.AspNetCore.Mvc;

namespace MedicationTracking.Features.Medicine;

/// <summary>
/// 
/// </summary>
/// <param name="medicineId"></param>
public class GetMedicineInfoCommand(int medicineId) : IRequest<ActionResult<MedicineDtoWithId>>
{
    /// <summary>
    /// 
    /// </summary>
    public int MedicineId { get; } = medicineId;
}
