using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfigurations;

public class CustomizedImageConfiguration : IEntityTypeConfiguration<CustomizedImage>
{
    public void Configure(EntityTypeBuilder<CustomizedImage> builder)
    {
        builder.ToTable("CustomizedImages").HasKey(ci => ci.Id);

        builder.Property(ci => ci.Id).HasColumnName("Id").IsRequired();
        builder.Property(ci => ci.ImageUrl).HasColumnName("ImageUrl").IsRequired();
        builder.Property(ci => ci.PrintAreaId).HasColumnName("PrintAreaId").IsRequired();
        builder.Property(ci => ci.PromptId).HasColumnName("PromptId").IsRequired();
        builder.Property(ci => ci.X).HasColumnName("x").IsRequired();
        builder.Property(ci => ci.Y).HasColumnName("y").IsRequired();
        builder.Property(ci => ci.CreatedDate).HasColumnName("CreatedDate").IsRequired();
        builder.Property(ci => ci.UpdatedDate).HasColumnName("UpdatedDate");
        builder.Property(ci => ci.DeletedDate).HasColumnName("DeletedDate");

        builder.HasOne(ci => ci.PrintArea).WithOne(pa => pa.CustomizedImage).HasForeignKey<CustomizedImage>(ci => ci.PrintAreaId);
        builder.HasQueryFilter(ci => !ci.DeletedDate.HasValue);
    }
}