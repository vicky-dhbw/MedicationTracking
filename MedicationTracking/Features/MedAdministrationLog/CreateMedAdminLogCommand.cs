using MediatR;
using MedicationTracking.Models;
using Microsoft.AspNetCore.Mvc;

namespace MedicationTracking.Features.MedAdministrationLog;

/// <summary>
///
/// </summary>
/// <param name="medAdministrationLogBase"></param>
public class CreateMedAdminLogCommand(MedAdministrationLogBase medAdministrationLogBase)
    : IRequest<ActionResult<MedAdministrationLogBaseWithId>>
{
    /// <summary>
    ///
    /// </summary>
    public MedAdministrationLogBase MedAdministrationLogBaseWithId { get; set; } =
        medAdministrationLogBase;
}
