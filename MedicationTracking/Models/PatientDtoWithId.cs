using Data.Models;

namespace MedicationTracking.Models;

public class PatientDtoWithId(
    int patientId,
    string firstName,
    string lastName,
    DateTime dateOfBirth,
    string gender,
    int roomNo
) : PatientDto(firstName, lastName, dateOfBirth, gender, roomNo)
{
    public int PatientId { get; set; } = patientId;

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
