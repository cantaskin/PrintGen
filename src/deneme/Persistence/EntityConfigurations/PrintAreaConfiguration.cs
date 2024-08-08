using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfigurations;

public class PrintAreaConfiguration : IEntityTypeConfiguration<PrintArea>
{
    public void Configure(EntityTypeBuilder<PrintArea> builder)
    {
        builder.ToTable("PrintAreas").HasKey(pa => pa.Id);

        builder.Property(pa => pa.Id).HasColumnName("Id").IsRequired();
        builder.Property(pa => pa.PrintAreaNameId).HasColumnName("PrintAreaNameId").IsRequired();
        builder.Property(pa => pa.ProductId).HasColumnName("ProductId").IsRequired();
        builder.Property(pa => pa.CustomizedImageId).HasColumnName("CustomizedImageId");
        builder.Property(pa => pa.X).HasColumnName("x").IsRequired();
        builder.Property(pa => pa.Y).HasColumnName("y").IsRequired();
        builder.Property(pa => pa.CreatedDate).HasColumnName("CreatedDate").IsRequired();
        builder.Property(pa => pa.UpdatedDate).HasColumnName("UpdatedDate");
        builder.Property(pa => pa.DeletedDate).HasColumnName("DeletedDate");

        builder.HasOne(pa => pa.CustomizedImage).WithOne(ci => ci.PrintArea).HasForeignKey<PrintArea>(pa => pa.CustomizedImageId);
        builder.HasOne(pi => pi.PrintAreaName);

        builder.HasQueryFilter(pa => !pa.DeletedDate.HasValue);
    }
}