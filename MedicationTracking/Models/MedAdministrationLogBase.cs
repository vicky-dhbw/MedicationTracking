namespace MedicationTracking.Models;

/// <summary>
///
/// </summary>
/// <param name="scheduleId"></param>
/// <param name="medAdminStatus"></param>
/// <param name="medAdminNote"></param>
public class MedAdministrationLogBase(int scheduleId, int medAdminStatus, string medAdminNote)
{
    /// <summary>
    ///
    /// </summary>
    public int ScheduleId { get; set; } = scheduleId;

    /// <summary>
    ///
    /// </summary>
    public int MedAdminStatus { get; set; } = medAdminStatus;

    /// <summary>
    ///
    /// </summary>
    public string MedAdminNote { get; set; } = medAdminNote;
}
