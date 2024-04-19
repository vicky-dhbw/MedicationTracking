using Data.Models;

namespace MedicationTracking.Models;

public class PatientDto(int patientId, string firstName, string lastName, DateTime dateOfBirth, string gender, int roomNo)
{
    public int PatientId { get; set; } = patientId;

    public string FirstName { get; set; } = firstName;

    public string LastName { get; set; } = lastName;

    public DateTime DateOfBirth { get; set; } = dateOfBirth;

    public string Gender { get; set; } = gender;

    public int RoomNo { get; set; } = roomNo;

    public static implicit operator PatientDto(Patient patient)
    {
        var patientDto = new PatientDto(patient.PatientId, patient.FirstName, patient.LastName, patient.DateOfBirth,
            patient.Gender, patient.RoomNo);

        return patientDto;
    }
}