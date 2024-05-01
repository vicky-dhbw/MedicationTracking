using MediatR;
using MedicationTracking.Models;
using Microsoft.AspNetCore.Mvc;

namespace MedicationTracking.Features.Medicine;

/// <summary>
/// 
/// </summary>
public class GetAllMedsCommand: IRequest<ActionResult<List<MedicineDtoWithEffects>>>
{
}