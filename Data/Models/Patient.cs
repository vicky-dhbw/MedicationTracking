using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Models;

public class Patient
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int PatientId { get; set; }

    [Required, StringLength(100)]
    public string FirstName { get; set; }

    [Required, StringLength(100)]
    public string LastName { get; set; }

    [Required]
    public DateTime DateOfBirth { get; set; }

    [Required, StringLength(24)]
    public string Gender { get; set; }

    [Required]
    public int RoomNo { get; set; }

    public Patient(
        string firstName,
        string lastName,
        DateTime dateOfBirth,
        string gender,
        int roomNo
    )
    {
        FirstName = firstName;
        LastName = lastName;
        DateOfBirth = dateOfBirth;
        Gender = gender;
        RoomNo = roomNo;
    }
}
