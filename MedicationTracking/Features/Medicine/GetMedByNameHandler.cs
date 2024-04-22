using MediatR;
using MedicationTracking.Models;
using Microsoft.AspNetCore.Mvc;

namespace MedicationTracking.Features.Medicine;

/// <summary>
///
/// </summary>
/// <param name="mediator"></param>
public class GetMedByNameHandler(IMediator mediator)
    : IRequestHandler<GetMedByNameCommand, ActionResult<MedicineDtoWithId>>
{
    /// <summary>
    ///
    /// </summary>
    /// <param name="request"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public async Task<ActionResult<MedicineDtoWithId>> Handle(
        GetMedByNameCommand request,
        CancellationToken cancellationToken
    )
    {
        var medicineInDb = (
            await mediator.Send(
                new GetMedicineFromDatabaseCommand(request.Medicine),
                cancellationToken
            )
        ).Value;

        if (medicineInDb == null)
            return new NotFoundObjectResult("Medicine does not exist in the database!");
        return new MedicineDtoWithId(
            medicineInDb.MedicineId,
            medicineInDb.GenericName,
            medicineInDb.BrandName,
            medicineInDb.Color,
            medicineInDb.Form,
            medicineInDb.AdministrationMethod
        );
    }
}
