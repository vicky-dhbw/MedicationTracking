using Data.Models;

namespace MedicationTracking.Utility;

/// <summary>
///
/// </summary>
public class TimeCategoryService
{
    /// <summary>
    ///
    /// </summary>
    private readonly List<TimeCategoryTracking> _timeCategories = new();

    /// <summary>
    ///
    /// </summary>
    public TimeCategoryService()
    {
        _timeCategories.Add(
            new TimeCategoryTracking(1, new TimeSpan(5, 0, 0), new TimeSpan(7, 59, 59))
        );
        _timeCategories.Add(
            new TimeCategoryTracking(2, new TimeSpan(8, 0, 0), new TimeSpan(10, 59, 59))
        );
        _timeCategories.Add(
            new TimeCategoryTracking(3, new TimeSpan(11, 0, 0), new TimeSpan(11, 59, 59))
        );
        _timeCategories.Add(
            new TimeCategoryTracking(4, new TimeSpan(12, 0, 0), new TimeSpan(13, 59, 59))
        );
        _timeCategories.Add(
            new TimeCategoryTracking(5, new TimeSpan(17, 0, 0), new TimeSpan(18, 59, 59))
        );
        _timeCategories.Add(
            new TimeCategoryTracking(6, new TimeSpan(19, 0, 0), new TimeSpan(20, 59, 59))
        );
        _timeCategories.Add(
            new TimeCategoryTracking(7, new TimeSpan(21, 0, 0), new TimeSpan(22, 59, 59))
        );
    }

    /// <summary>
    ///
    /// </summary>
    /// <returns></returns>
    public TimeCategoryTracking GetTimeCategory()
    {
        var currentTime = DateTime.Now.TimeOfDay;
        return _timeCategories.FirstOrDefault(c =>
            currentTime >= c.StartTime && currentTime <= c.EndTime
        )!;
    }
}
