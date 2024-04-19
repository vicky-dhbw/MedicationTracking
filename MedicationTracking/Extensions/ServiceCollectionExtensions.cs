using Data.Database;
using Microsoft.EntityFrameworkCore;

namespace MedicationTracking.Extensions;

public static class ServiceCollectionExtensions
{
    public static void ConfigureServices(this IServiceCollection services, IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("MedicationTrackingDB");
        services.AddDbContext<MedicationTrackingContext>(options =>
        {
            options.UseMySql(connectionString,ServerVersion.AutoDetect(connectionString), mySqlOptions =>
            {
                mySqlOptions.MigrationsAssembly("Data").MigrationsHistoryTable("MigrationHistory");
            });
        });

    }
}