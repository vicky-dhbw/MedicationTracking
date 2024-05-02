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
public class AddMedicationEffectHandler(IMedicationTrackingRepository repository)
    : IRequestHandler<AddMedicationEffectCommand, ActionResult<MedicationEffectResponseDto>>
{
    /// <summary>
    ///
    /// </summary>
    /// <param name="request"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public async Task<ActionResult<MedicationEffectResponseDto>> Handle(
        AddMedicationEffectCommand request,
        CancellationToken cancellationToken
    )
    {
        var medicineInDb = await repository.FirstOrDefault(
            new SameGenericAndBrandNameSpec(new MedicineBase(request.MedicationEffect.GenericName, request.MedicationEffect.BrandName)),
            cancellationToken
        );

        // ReSharper disable once ConditionIsAlwaysTrueOrFalseAccordingToNullableAPIContract
        if (medicineInDb == null)
            return new BadRequestObjectResult(
                "Medicine with the generic and brand does not exists!"
            );
        
        var medicineEffect = await repository.AddAsync(
            new MedicationEffect(
                medicineInDb.MedicineId,
                request.MedicationEffect.Gender,
                request.MedicationEffect.Description
            )
            {
                Medicine = medicineInDb
            },
            cancellationToken
        );

        await repository.SaveAsync(cancellationToken);

        return new MedicationEffectResponseDto(
            medicineEffect.EffectId,
            medicineEffect.MedicineId,
            medicineEffect.Gender,
            medicineEffect.Description
        );
    }
}
