using Data.Models;
using Microsoft.EntityFrameworkCore;

namespace Data.Database;

public class MedicationTrackingContext : DbContext
{
    public DbSet<Medicine> Medicines { get; set; }
    public DbSet<Patient> Patients { get; set; }
    public DbSet<MedicationSchedule> MedicationSchedules { get; set; }
    public DbSet<ScheduleChangeLog> ScheduleChangeLogs { get; set; }
    public DbSet<TimeCategory> TimeCategories { get; set; }
    public DbSet<MedicationEffect> MedicationEffects { get; set; }
    public DbSet<QrCode> QrCodes { get; set; }
    public DbSet<MedAdministrationLog> MedAdministrationLogs { get; set; }
    
    public MedicationTrackingContext(DbContextOptions options) : base(options)
    {
    }
}