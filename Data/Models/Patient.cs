using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Models;

public class Patient(
    string firstName,
    string lastName,
    DateTime dateOfBirth,
    string gender,
    int roomNo
)
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int PatientId { get; set; }

    [Required, StringLength(100)]
    public string FirstName { get; set; } = firstName;

    [Required, StringLength(100)]
    public string LastName { get; set; } = lastName;

    [Required]
    public DateTime DateOfBirth { get; set; } = dateOfBirth;

    [Required, StringLength(24)]
    public string Gender { get; set; } = gender;

    [Required]
    public int RoomNo { get; set; } = roomNo;
}
