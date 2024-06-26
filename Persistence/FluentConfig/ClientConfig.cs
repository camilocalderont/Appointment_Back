using Domain.Models.Appointment;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace Persistence.FluentConfig;

public class ClientConfig
{
    public ClientConfig(EntityTypeBuilder<Client> entity)
    {
        entity.ToTable("Client");
        entity.HasKey(x => x.Id);

        entity.Property(p => p.VcIdentificationNumber).IsRequired().HasMaxLength(100);
        entity.Property(p => p.VcPhone).IsRequired();
        entity.Property(p => p.VcFullName).IsRequired().HasMaxLength(200);
        entity.Property(p => p.VcEmail).IsRequired();
        entity.Property(p => p.BIsActived).HasDefaultValue(true).IsRequired();
    }
}