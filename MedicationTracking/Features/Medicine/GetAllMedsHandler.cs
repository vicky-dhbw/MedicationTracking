using MediatR;
using MedicationTracking.Models;
using MedicationTracking.Repository;
using MedicationTracking.Specifications;
using Microsoft.AspNetCore.Mvc;

namespace MedicationTracking.Features.Medicine;

/// <summary>
///
/// </summary>
/// <param name="repository"></param>
/// <param name="mediator"></param>
public class GetAllMedsHandler(IMedicationTrackingRepository repository, IMediator mediator)
    : IRequestHandler<GetAllMedsCommand, ActionResult<List<MedicineDtoWithEffects>>>
{
    /// <summary>
    ///
    /// </summary>
    /// <param name="request"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public async Task<ActionResult<List<MedicineDtoWithEffects>>> Handle(
        GetAllMedsCommand request,
        CancellationToken cancellationToken
    )
    {
        var medicinesInDb = (
            await repository.ListAsync(new AllMedsSpec(), cancellationToken)
        ).ToList();
        var medicineDtosWithEffects = new List<MedicineDtoWithEffects>();

        foreach (var medicine in medicinesInDb)
        {
            var medicineDtoWithEffects = (
                await mediator.Send(
                    new GetAllMedEffectsCommand(
                        new MedicineBase(medicine.GenericName, medicine.BrandName)
                    ),
                    cancellationToken
                )
            ).Value;

            medicineDtosWithEffects.Add(medicineDtoWithEffects!);
        }

        return medicineDtosWithEffects;
    }
}
