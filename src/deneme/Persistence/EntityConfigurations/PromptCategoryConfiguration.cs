using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfigurations;

public class PromptCategoryConfiguration : IEntityTypeConfiguration<PromptCategory>
{
    public void Configure(EntityTypeBuilder<PromptCategory> builder)
    {
        builder.ToTable("PromptCategories").HasKey(pc => pc.Id);

        builder.Property(pc => pc.Id).HasColumnName("Id").IsRequired();
        builder.Property(pc => pc.Name).HasColumnName("Name").IsRequired();
        builder.Property(pc => pc.Description).HasColumnName("Description").IsRequired();
        builder.Property(pc => pc.CreatedDate).HasColumnName("CreatedDate").IsRequired();
        builder.Property(pc => pc.UpdatedDate).HasColumnName("UpdatedDate");
        builder.Property(pc => pc.DeletedDate).HasColumnName("DeletedDate");

        builder.HasMany(pc => pc.Prompts)
            .WithOne(p => p.PromptCategory)
            .HasForeignKey(p => p.PromptCategoryId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasQueryFilter(pc => !pc.DeletedDate.HasValue);
    }
}