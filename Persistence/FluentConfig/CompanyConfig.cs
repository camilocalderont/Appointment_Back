using Domain.Models.Appointment;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace Persistence.FluentConfig;

public class CompanyConfig
{
    public CompanyConfig(EntityTypeBuilder<Company> entity)
    {
        entity.ToTable("Company");
        entity.HasKey(x => x.Id);
        
        entity.Property(p => p.VcName).IsRequired().HasMaxLength(200);
        entity.Property(p => p.VcDescription).HasMaxLength(1000).IsRequired(false);
        entity.Property(p => p.VcPhone).IsRequired().HasMaxLength(20);
        entity.Property(p => p.VcPrincipalAddress).HasMaxLength(500).IsRequired(false);
        entity.Property(p => p.VcPrincipalEmail).IsRequired().HasMaxLength(200);
        entity.Property(p => p.VcLegalRepresentative).HasMaxLength(200).IsRequired(false);
        entity.Property(p => p.VcLogo).HasMaxLength(1000).IsRequired(false);
    }
}