using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfigurations;

public class OptionConfiguration : IEntityTypeConfiguration<Option>
{
    public void Configure(EntityTypeBuilder<Option> builder)
    {
        builder.ToTable("Options").HasKey(o => o.Id);

        builder.Property(o => o.Id).HasColumnName("Id").IsRequired();
        builder.Property(o => o.Name).HasColumnName("Name").IsRequired();
        builder.Property(o => o.Value).HasColumnName("Value").IsRequired();
        builder.Property(o => o.CreatedDate).HasColumnName("CreatedDate").IsRequired();
        builder.Property(o => o.UpdatedDate).HasColumnName("UpdatedDate");
        builder.Property(o => o.DeletedDate).HasColumnName("DeletedDate");

        builder.HasOne(o => o.Layer)
            .WithMany(l => l.LayerOptions)
            .HasForeignKey(o => o.LayerId)
            .OnDelete(DeleteBehavior.NoAction);

        builder.HasOne(o => o.Placement)
            .WithMany(p => p.PlacementOptions)
            .HasForeignKey(o => o.PlacementId)
            .OnDelete(DeleteBehavior.NoAction);

        builder.HasOne(o => o.OrderItem)
            .WithMany(oi => oi.ProductOptions)
            .HasForeignKey(o => o.OrderItemId)
            .OnDelete(DeleteBehavior.NoAction);

        builder.HasQueryFilter(o => !o.DeletedDate.HasValue);
    }
}