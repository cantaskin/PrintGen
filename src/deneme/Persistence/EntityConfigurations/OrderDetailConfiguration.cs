using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfigurations;

public class OrderDetailConfiguration : IEntityTypeConfiguration<OrderDetail>
{
    public void Configure(EntityTypeBuilder<OrderDetail> builder)
    {
        builder.ToTable("OrderDetails").HasKey(od => od.Id);

        builder.Property(od => od.Id).HasColumnName("Id").IsRequired();
        builder.Property(od => od.CustomizedProductId).HasColumnName("CustomizedProductId").IsRequired();
        builder.Property(od => od.Price).HasColumnName("Price").IsRequired();
        builder.Property(od => od.Quantity).HasColumnName("Quantity").IsRequired();
        builder.Property(od => od.Discount).HasColumnName("Discount").IsRequired();
        builder.Property(od => od.CreatedDate).HasColumnName("CreatedDate").IsRequired();
        builder.Property(od => od.UpdatedDate).HasColumnName("UpdatedDate");
        builder.Property(od => od.DeletedDate).HasColumnName("DeletedDate");

        builder.HasOne(od => od.Order)
            .WithMany(o => o.OrderDetails)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasQueryFilter(od => !od.DeletedDate.HasValue);
    }
}