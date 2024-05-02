using Ardalis.Specification;
using Data.Models;

namespace MedicationTracking.Specifications;

/// <summary>
/// 
/// </summary>
public sealed class MedicationEffectByIdSpec : Specification<MedicationEffect>
{
    /// <summary>
    /// 
    /// </summary>
    /// <param name="effectId"></param>
    public MedicationEffectByIdSpec(int effectId)
    {
        Query.Where(me => me.EffectId == effectId);
    }
}