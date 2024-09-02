using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfigurations;

public class PlacementConfiguration : IEntityTypeConfiguration<Placement>
{
    public void Configure(EntityTypeBuilder<Placement> builder)
    {
        builder.ToTable("Placements").HasKey(p => p.Id);

        builder.Property(p => p.Id).HasColumnName("Id").IsRequired();
        builder.Property(p => p.PlacementName).HasColumnName("PlacementName").IsRequired();
        builder.Property(p => p.Technique).HasColumnName("Technique").IsRequired();
       // builder.Property(p => p.PlacementOptionId).HasColumnName("PlacementOptionId");
        builder.Property(p => p.CreatedDate).HasColumnName("CreatedDate").IsRequired();
        builder.Property(p => p.UpdatedDate).HasColumnName("UpdatedDate");
        builder.Property(p => p.DeletedDate).HasColumnName("DeletedDate");
        builder.Property(p => p.OrderItemId).HasColumnName("OrderItemId").IsRequired();


        builder.HasOne(p => p.OrderItem)
            .WithOne()
            .HasForeignKey<Placement>(p => p.OrderItemId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasMany(p => p.Layers)
            .WithOne(l => l.Placement)
            .HasForeignKey(l => l.PlacementId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasQueryFilter(p => !p.DeletedDate.HasValue);
    }
}