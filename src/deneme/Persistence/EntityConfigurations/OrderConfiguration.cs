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
        builder.Property(o => o.Number).HasColumnName("Number").IsRequired();
        builder.Property(o => o.UserId).HasColumnName("UserId").IsRequired();
        builder.Property(o => o.AddressId).HasColumnName("AddressId").IsRequired();
        builder.Property(o => o.CreatedDate).HasColumnName("CreatedDate").IsRequired();
        builder.Property(o => o.UpdatedDate).HasColumnName("UpdatedDate");
        builder.Property(o => o.DeletedDate).HasColumnName("DeletedDate");

        // User iliþkisi
        builder.HasOne(o => o.User)
            .WithMany(u => u.Orders)
            .HasForeignKey(o => o.UserId)
            .OnDelete(DeleteBehavior.Restrict);

        // Address iliþkisi
        builder.HasOne(o => o.Address)
            .WithMany(a => a.Orders)
            .HasForeignKey(o => o.AddressId)
            .OnDelete(DeleteBehavior.Restrict);

        // OrderTransport iliþkisi
        builder.HasOne(o => o.OrderTransport)
            .WithMany(ot => ot.Orders)
            .HasForeignKey(o => o.OrderTransportId)
            .OnDelete(DeleteBehavior.Restrict);

        // OrderDetails iliþkisi
        builder.HasMany(o => o.OrderDetails)
            .WithOne(od => od.Order)
            .HasForeignKey(od => od.OrderId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasQueryFilter(o => !o.DeletedDate.HasValue);
    }
}