using Ardalis.Specification;
using Data.Models;

namespace MedicationTracking.Specifications;

/// <summary>
/// 
/// </summary>
public sealed class TimeCategoryByDescriptionSpec : Specification<TimeCategory>
{
    /// <summary>
    /// The default constructor requires the direct query
    /// </summary>
    /// <param name="description"></param>
    public TimeCategoryByDescriptionSpec(string description)
    {
        Query.Where(t => t.Description == description);
    }
}