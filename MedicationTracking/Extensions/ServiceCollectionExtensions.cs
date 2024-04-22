using System.Reflection;
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
            options.UseLazyLoadingProxies();
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

        // Swagger xml documentation
        services.AddSwaggerGen(options =>
        {
            var xmlFilename = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
            options.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, xmlFilename));
        });
    }
}
