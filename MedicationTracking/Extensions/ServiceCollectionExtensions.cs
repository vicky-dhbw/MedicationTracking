using Data.Database;
using MedicationTracking.Repository;
using Microsoft.EntityFrameworkCore;

namespace MedicationTracking.Extensions;

public static class ServiceCollectionExtensions
{
    public static void ConfigureServices(
        this IServiceCollection services,
        IConfiguration configuration
    )
    {
        var connectionString = configuration.GetConnectionString("MedicationTrackingDB");

        // Adding DbContext from Data Project
        services.AddDbContext<MedicationTrackingContext>(options =>
        {
            options.UseMySql(
                connectionString,
                ServerVersion.AutoDetect(connectionString),
                mySqlOptions =>
                {
                    mySqlOptions
                        .MigrationsAssembly("Data")
                        .MigrationsHistoryTable("MigrationHistory");
                }
            );
        });

        // Registering all RequestHandlers
        services.AddMediatR(config =>
        {
            config.RegisterServicesFromAssemblies(typeof(Program).Assembly);
        });

        // Registering the repository
        services.AddScoped<IMedicationTrackingRepository, MedicationTrackingRepository>();
    }
}
