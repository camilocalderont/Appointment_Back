using Domain.Models.Appointment;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace Persistence.FluentConfig;

public class ClientConfig
{
    public ClientConfig(EntityTypeBuilder<Client> entity)
    {
        entity.ToTable("CLient");
        entity.HasKey(x => x.Id);

        entity.Property(p => p.VcIdentificationNumber).IsRequired().HasMaxLength(100);
        entity.Property(p => p.VcPhone).IsRequired();
        entity.Property(p => p.vcNickName).HasMaxLength(100);
        entity.Property(p => p.VcFirstName).IsRequired().HasMaxLength(50);
        entity.Property(p => p.VcSecondName).HasMaxLength(50);
        entity.Property(p => p.VcFirstLastName).IsRequired().HasMaxLength(50);
        entity.Property(p => p.VcSecondLastName).HasMaxLength(50);
        entity.Property(p => p.VcEmail).IsRequired();
        entity.Property(p => p.VcPassword).HasMaxLength(300);
        entity.Property(p=>p.BIsActived).HasDefaultValue(true).IsRequired();
    }
}