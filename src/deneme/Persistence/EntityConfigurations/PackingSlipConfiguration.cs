using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfigurations;

public class PackingSlipConfiguration : IEntityTypeConfiguration<PackingSlip>
{
    public void Configure(EntityTypeBuilder<PackingSlip> builder)
    {
        builder.ToTable("PackingSlips").HasKey(ps => ps.Id);

        builder.Property(ps => ps.Id).HasColumnName("Id").IsRequired();
        builder.Property(ps => ps.Email).HasColumnName("Email").IsRequired();
        builder.Property(ps => ps.Phone).HasColumnName("Phone").IsRequired();
        builder.Property(ps => ps.Message).HasColumnName("Message").IsRequired();
        builder.Property(ps => ps.LogoUrl).HasColumnName("LogoUrl").IsRequired();
        builder.Property(ps => ps.StoreName).HasColumnName("StoreName").IsRequired();
        builder.Property(ps => ps.CreatedDate).HasColumnName("CreatedDate").IsRequired();
        builder.Property(ps => ps.UpdatedDate).HasColumnName("UpdatedDate");
        builder.Property(ps => ps.DeletedDate).HasColumnName("DeletedDate");


        builder.HasMany(p => p.Customizations)
            .WithOne(c => c.PackingSlip)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasQueryFilter(ps => !ps.DeletedDate.HasValue);
    }
}