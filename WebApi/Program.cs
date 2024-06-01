using System.Text.Json.Serialization;
using Adapters.Mappers;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using Persistence.Context;
using Persistence.Repositories;
using UseCases.Cases.Appointment;
using AutoMapper;

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

// Register AutoMapper
var mapperConfig = new MapperConfiguration(mc =>
{
    mc.AddProfile(new AutoMapperProfile()); // Añade tu perfil de mapeo
});

IMapper mapper = mapperConfig.CreateMapper();
builder.Services.AddSingleton(mapper);

builder.Services.AddScoped<DbContext, ApplicationDbContext>();
builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
builder.Services.AddScoped(typeof(ICustomMapper<,>), typeof(AutoMapperAdapter<,>));
builder.Services.AddScoped<CreateClientUseCase>();

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