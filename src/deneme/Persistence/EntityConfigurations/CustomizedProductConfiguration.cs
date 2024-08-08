using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfigurations;

public class CustomizedProductConfiguration : IEntityTypeConfiguration<CustomizedProduct>
{
    public void Configure(EntityTypeBuilder<CustomizedProduct> builder)
    {
        builder.ToTable("CustomizedProducts").HasKey(cp => cp.Id);

        builder.Property(cp => cp.Id).HasColumnName("Id").IsRequired();
        builder.Property(cp => cp.ProductId).HasColumnName("ProductId").IsRequired();
        builder.Property(cp => cp.UserId).HasColumnName("UserId").IsRequired();
        builder.Property(cp => cp.IsPublished).HasColumnName("IsPublished").IsRequired();
        builder.Property(cp => cp.CreatedDate).HasColumnName("CreatedDate").IsRequired();
        builder.Property(cp => cp.UpdatedDate).HasColumnName("UpdatedDate");
        builder.Property(cp => cp.DeletedDate).HasColumnName("DeletedDate");

        builder.HasQueryFilter(cp => !cp.DeletedDate.HasValue);
    }
}