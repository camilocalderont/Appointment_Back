using System.Text.Json.Serialization;
using Microsoft.EntityFrameworkCore;
using Persistence.Context;

DotNetEnv.Env.Load();
var builder = WebApplication.CreateBuilder(args);

string connectionString = Environment.GetEnvironmentVariable("CONNECTION_STRING");
Console.WriteLine(connectionString);
var myAllowSpecificOrigins = "_myAllowSpecificOrigins";
builder.Services.AddControllers().AddJsonOptions(opt =>
{
    opt.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
});
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
bool devEnv = builder.Environment.IsDevelopment();

builder.Services.AddDbContextFactory<ApplicationDbContext>(options =>
{
    if (devEnv)
    {
        options.UseSqlServer(connectionString)
            .EnableSensitiveDataLogging(true)
            .EnableDetailedErrors(true);
    }
    else
    {
        options.UseSqlServer(connectionString);
    }

}, ServiceLifetime.Transient);

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

using (var scope = app.Services.CreateScope())
{
    var context = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
    context.Database.Migrate();
    //context.EnsureSeeded();
}

app.MapGet("/", () => "Hello World!");

app.UseHttpsRedirection();
app.UseCors(myAllowSpecificOrigins);
app.UseAuthorization();

app.MapControllers();

app.Run();