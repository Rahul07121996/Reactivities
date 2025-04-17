using Microsoft.EntityFrameworkCore;
using Presistance;
using System;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddDbContext<AppDbContext>(opt =>
{
    opt.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnections"));
});

var app = builder.Build();



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
