using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfigurations;

public class GiftConfiguration : IEntityTypeConfiguration<Gift>
{
    public void Configure(EntityTypeBuilder<Gift> builder)
    {
        builder.ToTable("Gifts").HasKey(g => g.Id);

        builder.Property(g => g.Id).HasColumnName("Id").IsRequired();
        builder.Property(g => g.Subject).HasColumnName("Subject").IsRequired();
        builder.Property(g => g.Message).HasColumnName("Message").IsRequired();
        builder.Property(g => g.CreatedDate).HasColumnName("CreatedDate").IsRequired();
        builder.Property(g => g.UpdatedDate).HasColumnName("UpdatedDate");
        builder.Property(g => g.DeletedDate).HasColumnName("DeletedDate");
        builder.Property(g => g.CustomizationId).HasColumnName("CustomizationId").IsRequired();


        builder.HasOne(g => g.Customization)
            .WithOne(c => c.Gift)
            .HasForeignKey<Gift>(g => g.CustomizationId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasQueryFilter(g => !g.DeletedDate.HasValue);
    }
}