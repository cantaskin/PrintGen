using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfigurations;

public class OrderConfiguration : IEntityTypeConfiguration<Order>
{
    public void Configure(EntityTypeBuilder<Order> builder)
    {
        builder.ToTable("Orders").HasKey(o => o.Id);

        builder.Property(o => o.Id).HasColumnName("Id").IsRequired();
        builder.Property(o => o.AddressId).HasColumnName("AddressId").IsRequired();
        builder.Property(o => o.RetailCostId).HasColumnName("RetailCostId").IsRequired();
        builder.Property(o => o.CustomizationId).HasColumnName("CustomizationId");
        builder.Property(o => o.Shipping).HasColumnName("Shipping");
        builder.Property(o => o.CreatedDate).HasColumnName("CreatedDate").IsRequired();
        builder.Property(o => o.UpdatedDate).HasColumnName("UpdatedDate");
        builder.Property(o => o.DeletedDate).HasColumnName("DeletedDate");


        builder.HasQueryFilter(o => !o.DeletedDate.HasValue);
    }
}