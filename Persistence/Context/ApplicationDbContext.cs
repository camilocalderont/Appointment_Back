using Domain.Models.Appointment;
using Microsoft.EntityFrameworkCore;
using Persistence.FluentConfig;

namespace Persistence.Context;

public class ApplicationDbContext:DbContext
{
    public ApplicationDbContext(DbContextOptions options) : base(options)
    {
        
    }
    
    public DbSet<Client> Client { get; set; }
    public DbSet<Client> Company { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        //Appointments Fluent Config
        new ClientConfig(modelBuilder.Entity<Client>()); 
        new CompanyConfig(modelBuilder.Entity<Company>()); 
    }
}