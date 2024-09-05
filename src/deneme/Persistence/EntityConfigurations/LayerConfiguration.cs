using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfigurations;

public class LayerConfiguration : IEntityTypeConfiguration<Layer>
{
    public void Configure(EntityTypeBuilder<Layer> builder)
    {
        builder.ToTable("Layers").HasKey(l => l.Id);

        builder.Property(l => l.Id).HasColumnName("Id").IsRequired();
        builder.Property(l => l.Type).HasColumnName("Type").IsRequired();
        builder.Property(l => l.Url).HasColumnName("Url").IsRequired();
        builder.Property(l => l.CreatedDate).HasColumnName("CreatedDate").IsRequired();
        builder.Property(l => l.UpdatedDate).HasColumnName("UpdatedDate");
        builder.Property(l => l.DeletedDate).HasColumnName("DeletedDate");
        builder.Property(l => l.PlacementId).HasColumnName("PlacementId").IsRequired();

        //
        // // LayerOptions ile olan iliþkiyi yapýlandýrma
        // builder.HasMany(l => l.LayerOptions)
        //     .WithOne(lo => lo.Layer)
        //     .HasForeignKey(lo => lo.LayerId)
        //     .OnDelete(DeleteBehavior.Cascade);

        builder.HasOne(l => l.Position)
            .WithOne(p => p.Layer)
            .HasForeignKey<Layer>(l => l.PositionId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasOne(l => l.Placement)
            .WithMany(p => p.Layers) // Explicitly specify the navigation property
            .HasForeignKey(l => l.PlacementId)
            .OnDelete(DeleteBehavior.Cascade);


        builder.HasQueryFilter(l => !l.DeletedDate.HasValue);
    }
}