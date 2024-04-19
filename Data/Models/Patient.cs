using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Models;

public class Patient
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int PatientId { get; set; }

    [Required, StringLength(100)]
    public required string FirstName { get; set; }

    [Required, StringLength(100)]
    public required string LastName { get; set; }

    [Required]
    public DateTime DateOfBirth { get; set; }

    [Required, StringLength(24)]
    public required string Gender { get; set; }

    [Required]
    public int RoomNo { get; set; }
}