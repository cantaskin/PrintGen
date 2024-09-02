using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfigurations;

public class CustomizationConfiguration : IEntityTypeConfiguration<Customization>
{
    public void Configure(EntityTypeBuilder<Customization> builder)
    {
        builder.ToTable("Customizations").HasKey(c => c.Id);

        builder.Property(c => c.Id).HasColumnName("Id").IsRequired();
        builder.Property(c => c.GiftId).HasColumnName("GiftId");
       // builder.Property(c => c.Gift).HasColumnName("Gift");
        builder.Property(c => c.PackingSlipId).HasColumnName("PackingSlipId").IsRequired();
      //  builder.Property(c => c.PackingSlip).HasColumnName("PackingSlip").IsRequired();
        builder.Property(c => c.CreatedDate).HasColumnName("CreatedDate").IsRequired();
        builder.Property(c => c.UpdatedDate).HasColumnName("UpdatedDate");
        builder.Property(c => c.DeletedDate).HasColumnName("DeletedDate");
        builder.Property(c => c.OrderId).HasColumnName("OrderId").IsRequired();



        builder.HasOne(c => c.Order).
            WithOne().
            HasForeignKey<Customization>(c => c.OrderId)
            .OnDelete(DeleteBehavior.Cascade);
        /*
        // Configure the Gift relationship with a foreign key
        builder.HasOne(c => c.Gift)
            .WithOne() // Assuming Gift has no reference to Customization
            .HasForeignKey<Customization>(c => c.GiftId)
            .OnDelete(DeleteBehavior.Cascade);

        // Configure the relationship with PackingSlip
        builder.HasOne(c => c.PackingSlip)
            .WithMany(ps => ps.Customizations)  // Assuming PackingSlip can have multiple Customizations
            .HasForeignKey(c => c.PackingSlipId)
            .OnDelete(DeleteBehavior.Cascade);*/

        builder.HasQueryFilter(c => !c.DeletedDate.HasValue);
    }
}