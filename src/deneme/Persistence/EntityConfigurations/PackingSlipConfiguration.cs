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
        builder.Property(ps => ps.CustomerOrderId).HasColumnName("CustomerOrderId").IsRequired();
        builder.Property(ps => ps.CreatedDate).HasColumnName("CreatedDate").IsRequired();
        builder.Property(ps => ps.UpdatedDate).HasColumnName("UpdatedDate");
        builder.Property(ps => ps.DeletedDate).HasColumnName("DeletedDate");


        // Configuring the one-to-many relationship with Customization
        builder.HasMany(ps => ps.Customizations) // Reference to Customizations list
            .WithOne() // Reference back to PackingSlip in Customization
            .HasForeignKey(c => c.PackingSlipId); // Foreign key defined in Customization; // Setting up Cascade delete behavior

        builder.HasQueryFilter(ps => !ps.DeletedDate.HasValue);
    }
}