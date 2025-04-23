using Application.Repositry;
using Microsoft.EntityFrameworkCore;
using Presistance;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddDbContext<AppDbContext>(opt =>
{
    opt.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnections"));
});
builder.Services.AddScoped<IActivityRepositry,ActivityRepository>();

builder.Services.AddCors();

var app = builder.Build();

app.UseCors(option =>
{
    option.AllowAnyHeader().AllowAnyMethod().WithOrigins("http://localhost:3000", "http://localhost:3001");
});

app.MapControllers();
using var scope = app.Services.CreateScope();
var services = scope.ServiceProvider;

try
{
    var context  = services.GetRequiredService<AppDbContext>();
    await context.Database.MigrateAsync();

    await DbIntializer.SeedData(context);
}
catch (Exception ex)
{
    var logger = services.GetRequiredService<ILogger<Program>>();
    logger.LogError(ex, "An error occur during Migration");
    throw;
}

app.Run();
