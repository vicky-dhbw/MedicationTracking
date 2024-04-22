using Ardalis.Specification;
using Data.Models;

namespace MedicationTracking.Specifications;

/// <summary>
/// 
/// </summary>
public sealed class GetTimeCategoryByIdSpec : Specification<TimeCategory>
{
    /// <summary>
    /// 
    /// </summary>
    /// <param name="timeCategoryId"></param>
    public GetTimeCategoryByIdSpec(int timeCategoryId)
    {
        Query.Where(t => t.TimeCategoryId == timeCategoryId);
    }
}