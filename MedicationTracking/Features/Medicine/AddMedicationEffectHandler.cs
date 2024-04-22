using Data.Models;
using MediatR;
using MedicationTracking.Models;
using MedicationTracking.Repository;
using MedicationTracking.Specifications;
using Microsoft.AspNetCore.Mvc;

namespace MedicationTracking.Features.Medicine;

public class AddMedicationEffectHandler(IMedicationTrackingRepository repository)
    : IRequestHandler<AddMedicationEffectCommand, ActionResult<MedicationEffectResponseDto>>
{
    public async Task<ActionResult<MedicationEffectResponseDto>> Handle(
        AddMedicationEffectCommand request,
        CancellationToken cancellationToken
    )
    {
        var medicineInDb = await repository.FirstOrDefault(
            new SameGenericAndBrandNameSpec(request.MedicationEffect),
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
