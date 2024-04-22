using MediatR;
using MedicationTracking.Models;
using Microsoft.AspNetCore.Mvc;

namespace MedicationTracking.Features.Medicine;

/// <summary>
///
/// </summary>
/// <param name="medicineBase"></param>
public class GetMedicineFromDatabaseCommand(MedicineBase medicineBase)
    : IRequest<ActionResult<Data.Models.Medicine>>
{
    /// <summary>
    ///
    /// </summary>
    public MedicineBase MedicineBase { get; } = medicineBase;
}
