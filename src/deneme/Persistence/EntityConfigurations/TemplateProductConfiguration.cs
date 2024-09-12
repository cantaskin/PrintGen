using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfigurations;

public class TemplateProductConfiguration : IEntityTypeConfiguration<TemplateProduct>
{
    public void Configure(EntityTypeBuilder<TemplateProduct> builder)
    {
        builder.ToTable("TemplateProducts").HasKey(tp => tp.Id);

        builder.Property(tp => tp.Id).HasColumnName("Id").IsRequired();
        builder.Property(tp => tp.OrderCount).HasColumnName("OrderCount").IsRequired();
        builder.Property(tp => tp.UserId).HasColumnName("UserId").IsRequired();
        builder.Property(tp => tp.CreatedDate).HasColumnName("CreatedDate").IsRequired();
        builder.Property(tp => tp.UpdatedDate).HasColumnName("UpdatedDate");
        builder.Property(tp => tp.DeletedDate).HasColumnName("DeletedDate");

        builder.HasOne(tp => tp.User).WithMany(u => u.TemplateProducts).OnDelete(DeleteBehavior.NoAction);

        builder.HasMany(tp => tp.OrderItems);

        builder.HasQueryFilter(tp => !tp.DeletedDate.HasValue);
    }
}