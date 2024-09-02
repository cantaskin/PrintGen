using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfigurations;

public class RetailCostConfiguration : IEntityTypeConfiguration<RetailCost>
{
    public void Configure(EntityTypeBuilder<RetailCost> builder)
    {
        builder.ToTable("RetailCosts").HasKey(rc => rc.Id);

        builder.Property(rc => rc.Id).HasColumnName("Id").IsRequired();
        builder.Property(rc => rc.Currency).HasColumnName("Currency").IsRequired();
        builder.Property(rc => rc.Discount).HasColumnName("Discount").IsRequired();
        builder.Property(rc => rc.Shipping).HasColumnName("Shipping").IsRequired();
        builder.Property(rc => rc.Tax).HasColumnName("Tax").IsRequired();
        builder.Property(rc => rc.CreatedDate).HasColumnName("CreatedDate").IsRequired();
        builder.Property(rc => rc.UpdatedDate).HasColumnName("UpdatedDate");
        builder.Property(rc => rc.DeletedDate).HasColumnName("DeletedDate");
        builder.Property(rc => rc.OrderId).HasColumnName("OrderId").IsRequired();

        builder.HasOne(rc => rc.Order).WithOne().
            HasForeignKey<RetailCost>(rc => rc.OrderId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasQueryFilter(rc => !rc.DeletedDate.HasValue);
    }
}