using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfigurations;

public class PrintAreaNameConfiguration : IEntityTypeConfiguration<PrintAreaName>
{
    public void Configure(EntityTypeBuilder<PrintAreaName> builder)
    {
        builder.ToTable("PrintAreaNames").HasKey(pan => pan.Id);

        builder.Property(pan => pan.Id).HasColumnName("Id").IsRequired();
        builder.Property(pan => pan.Name).HasColumnName("Name").IsRequired();
        builder.Property(pan => pan.CreatedDate).HasColumnName("CreatedDate").IsRequired();
        builder.Property(pan => pan.UpdatedDate).HasColumnName("UpdatedDate");
        builder.Property(pan => pan.DeletedDate).HasColumnName("DeletedDate");

        builder.HasMany(pa => pa.PrintAreas);
        builder.HasQueryFilter(pan => !pan.DeletedDate.HasValue);
    }
}