using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfigurations;

public class PromptConfiguration : IEntityTypeConfiguration<Prompt>
{
    public void Configure(EntityTypeBuilder<Prompt> builder)
    {
        builder.ToTable("Prompts").HasKey(p => p.Id);

        builder.Property(p => p.Id).HasColumnName("Id").IsRequired();
        builder.Property(p => p.PromptString).HasColumnName("PromptString").IsRequired();
        builder.Property(p => p.CreatedDate).HasColumnName("CreatedDate").IsRequired();
        builder.Property(p => p.UpdatedDate).HasColumnName("UpdatedDate");
        builder.Property(p => p.DeletedDate).HasColumnName("DeletedDate");
        builder.Property(ci => ci.UserId).HasColumnName("UserId").IsRequired();


        builder.HasOne(ci => ci.User)
            .WithMany(u => u.Prompts)
            .HasForeignKey(ci => ci.UserId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasMany(p => p.Images).
            WithOne(ci => ci.ImagePrompt);

        builder.HasOne(p => p.PromptCategory).
            WithMany(pc => pc.Prompts)
            .HasForeignKey(p => p.PromptCategoryId)
            .OnDelete(DeleteBehavior.Cascade); ;

        builder.HasQueryFilter(p => !p.DeletedDate.HasValue);
    }
}