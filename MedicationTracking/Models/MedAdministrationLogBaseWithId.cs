namespace MedicationTracking.Models;

/// <summary>
///
/// </summary>
/// <param name="medLogId"></param>
/// <param name="scheduleId"></param>
/// <param name="medAdminTime"></param>
/// <param name="medAdminStatus"></param>
/// <param name="medAdminNote"></param>
public class MedAdministrationLogBaseWithId(
    int medLogId,
    int scheduleId,
    DateTime medAdminTime,
    int medAdminStatus,
    string medAdminNote
) : MedAdministrationLogBase(scheduleId, medAdminStatus, medAdminNote)
{
    /// <summary>
    ///
    /// </summary>
    public int MedLogId { get; set; } = medLogId;

    /// <summary>
    ///
    /// </summary>
    public DateTime MedAdminTime { get; set; } = medAdminTime;
}
