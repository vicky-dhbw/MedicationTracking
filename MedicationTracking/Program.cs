using MedicationTracking.Extensions;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddControllers();
builder.Services.AddSwaggerGen();
builder.Services.AddCors(options => {
    options.AddPolicy("_myAllowSpecificOrigins",
        b => b.WithOrigins("http://localhost:8100") // Replace with the origin of your Angular app
            .AllowAnyHeader()
            .AllowAnyMethod());
});
builder.Services.ConfigureServices(builder.Configuration);
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.MapControllers();
app.UseCors("_myAllowSpecificOrigins");
app.Run();
