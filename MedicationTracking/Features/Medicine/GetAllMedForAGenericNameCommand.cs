using MediatR;
using MedicationTracking.Models;
using Microsoft.AspNetCore.Mvc;

namespace MedicationTracking.Features.Medicine;

/// <summary>
///
/// </summary>
/// <param name="genericName"></param>
public class GetAllMedForAGenericNameCommand(string genericName)
    : IRequest<ActionResult<List<MedicineDtoWithId>>>
{
    /// <summary>
    ///
    /// </summary>
    public string GenericName { get; } = genericName;
}
