using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace MedicationTracking.Features.Medicine;

/// <summary>
///
/// </summary>
/// <param name="genericName"></param>
/// <param name="brandName"></param>
public class DeleteMedicineCommand(string genericName, string brandName) : IRequest<ActionResult>
{
    /// <summary>
    ///
    /// </summary>
    public string GenericName { get; set; } = genericName;

    /// <summary>
    ///
    /// </summary>
    public string BrandName { get; set; } = brandName;
}
