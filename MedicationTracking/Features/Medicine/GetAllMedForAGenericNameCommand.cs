using MediatR;
using MedicationTracking.Models;
using Microsoft.AspNetCore.Mvc;

namespace MedicationTracking.Features.Medicine;

public class GetAllMedForAGenericNameCommand(string genericName)
    : IRequest<ActionResult<List<MedicineDtoWithId>>>
{
    public string GenericName { get; } = genericName;
}
