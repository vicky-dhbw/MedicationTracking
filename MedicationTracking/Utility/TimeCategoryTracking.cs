namespace MedicationTracking.Utility;

/// <summary>
///
/// </summary>
public class TimeCategoryTracking(int timeCategoryId, TimeSpan startTime, TimeSpan endTime)
{
    /// <summary>
    ///
    /// </summary>
    public int TimeCategoryId { get; set; } = timeCategoryId;

    /// <summary>
    ///
    /// </summary>
    public TimeSpan StartTime { get; set; } = startTime;

    /// <summary>
    ///
    /// </summary>
    public TimeSpan EndTime { get; set; } = endTime;
}
