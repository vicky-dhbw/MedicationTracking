namespace MedicationTracking.Models;

/// <summary>
/// 
/// </summary>
/// <param name="patientId"></param>
/// <param name="firstName"></param>
/// <param name="lastName"></param>
/// <param name="gender"></param>
/// <param name="roomNo"></param>
public class PatientBase(int patientId, string firstName, string lastName, string gender, int roomNo)
{
    /// <summary>
    /// 
    /// </summary>
    public int PatientId { get; set; } = patientId;
    /// <summary>
    /// 
    /// </summary>
    public string FirstName { get; set; } = firstName;
    /// <summary>
    /// 
    /// </summary>
    public string LastName { get; set; } = lastName;

    /// <summary>
    /// 
    /// </summary>
    public string Gender { get; set; } = gender;

    /// <summary>
    /// 
    /// </summary>
    public int RoomNo { get; set; } = roomNo;
}