using Data.Models;
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
public class GetAllMedEffectsHandler(IMedicationTrackingRepository repository)
    : IRequestHandler<GetAllMedEffectsCommand, ActionResult<MedicineDtoWithEffects>>
{
    /// <summary>
    ///
    /// </summary>
    /// <param name="request"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public async Task<ActionResult<MedicineDtoWithEffects>> Handle(
        GetAllMedEffectsCommand request,
        CancellationToken cancellationToken
    )
    {
        var medicineInDb = await repository.FirstOrDefault(
            new SameGenericAndBrandNameSpec(request.MedicineBase),
            cancellationToken
        );

        // ReSharper disable once ConditionIsAlwaysTrueOrFalseAccordingToNullableAPIContract
        if (medicineInDb == null)
            return new BadRequestObjectResult(
                "Medicine with the generic and brand does not exist!"
            );

        var medicationEffectsList = (
            await repository.ListAsync(
                new MedEffectsByMedIdSpec(medicineInDb.MedicineId),
                cancellationToken
            )
        )
            .Select(e => new MedicationEffectWithId(e.EffectId,e.Gender, e.Description!))
            .ToList();

        return new MedicineDtoWithEffects(
            medicineInDb.GenericName,
            medicineInDb.BrandName,
            medicineInDb.Color,
            medicineInDb.Form,
            medicineInDb.AdministrationMethod
        )
        {
            MedicationEffects = medicationEffectsList
        };
    }
}
