using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfigurations;

public class OrderTransportConfiguration : IEntityTypeConfiguration<OrderTransport>
{
    public void Configure(EntityTypeBuilder<OrderTransport> builder)
    {
        builder.ToTable("OrderTransports").HasKey(ot => ot.Id);

        builder.Property(ot => ot.Id).HasColumnName("Id").IsRequired();
        builder.Property(ot => ot.Name).HasColumnName("Name").IsRequired();
        builder.Property(ot => ot.CreatedDate).HasColumnName("CreatedDate").IsRequired();
        builder.Property(ot => ot.UpdatedDate).HasColumnName("UpdatedDate");
        builder.Property(ot => ot.DeletedDate).HasColumnName("DeletedDate");

        builder.HasQueryFilter(ot => !ot.DeletedDate.HasValue);

        // Ýliþkiyi buraya ekleyin
        builder.HasMany(ot => ot.Orders)
               .WithOne(o => o.OrderTransport)
               .HasForeignKey(o => o.OrderTransportId)
               .OnDelete(DeleteBehavior.Restrict);
    }
}