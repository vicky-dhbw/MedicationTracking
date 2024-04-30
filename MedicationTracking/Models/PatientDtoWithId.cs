using Data.Models;

namespace MedicationTracking.Models;

/// <summary>
/// 
/// </summary>
/// <param name="patientId"></param>
/// <param name="firstName"></param>
/// <param name="lastName"></param>
/// <param name="dateOfBirth"></param>
/// <param name="gender"></param>
/// <param name="roomNo"></param>
public class PatientDtoWithId(
    int patientId,
    string firstName,
    string lastName,
    DateTime dateOfBirth,
    string gender,
    int roomNo
) : PatientDto(firstName, lastName, dateOfBirth, gender, roomNo)
{
    /// <summary>
    /// 
    /// </summary>
    public int PatientId { get; set; } = patientId;

    /// <summary>
    /// 
    /// </summary>
    /// <param name="patient"></param>
    /// <returns></returns>
    public static implicit operator PatientDtoWithId(Patient patient)
    {
        return new PatientDtoWithId(
            patient.PatientId,
            patient.FirstName,
            patient.LastName,
            patient.DateOfBirth,
            patient.Gender,
            patient.RoomNo
        );
    }
}
