using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfigurations;

public class OrderItemConfiguration : IEntityTypeConfiguration<OrderItem>
{
    public void Configure(EntityTypeBuilder<OrderItem> builder)
    {
        builder.ToTable("OrderItems").HasKey(oi => oi.Id);
        builder.Property(oi => oi.Id).HasColumnName("Id").IsRequired();
        builder.Property(oi => oi.Source).HasColumnName("Source").IsRequired();
        builder.Property(oi => oi.CatalogVariantId).HasColumnName("CatalogVariantId").IsRequired();
        builder.Property(oi => oi.ExternalId).HasColumnName("ExternalId");
        builder.Property(oi => oi.Quantity).HasColumnName("Quantity").IsRequired();
        builder.Property(oi => oi.RetailPrice).HasColumnName("RetailPrice");
        builder.Property(oi => oi.Name).HasColumnName("Name");
        builder.Property(oi => oi.CreatedDate).HasColumnName("CreatedDate").IsRequired();
        builder.Property(oi => oi.UpdatedDate).HasColumnName("UpdatedDate");
        builder.Property(oi => oi.DeletedDate).HasColumnName("DeletedDate");
        builder.Property(oi => oi.OrderId).HasColumnName("OrderId").IsRequired();


        builder.HasMany(oi => oi.ProductOptions)
            .WithOne(po => po.OrderItem)
            .HasForeignKey(po => po.OrderItemId)
            .OnDelete(DeleteBehavior.NoAction);

        builder.HasMany(oi => oi.Placements)
            .WithOne(p => p.OrderItem)
            .HasForeignKey(p => p.OrderItemId);

        builder.HasOne(oi => oi.Order)
            .WithMany(o => o.OrderItems)
            .HasForeignKey(oi => oi.OrderId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasOne(oi => oi.TemplateProduct);

        builder.HasQueryFilter(oi => !oi.DeletedDate.HasValue);
    }
}