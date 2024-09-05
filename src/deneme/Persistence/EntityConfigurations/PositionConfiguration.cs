using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfigurations;

public class PositionConfiguration : IEntityTypeConfiguration<Position>
{
    public void Configure(EntityTypeBuilder<Position> builder)
    {
        builder.ToTable("Positions").HasKey(p => p.Id);

        builder.Property(p => p.Id).HasColumnName("Id").IsRequired();
        builder.Property(p => p.Width).HasColumnName("Width").IsRequired();
        builder.Property(p => p.Height).HasColumnName("Height").IsRequired();
        builder.Property(p => p.Top).HasColumnName("Top").IsRequired();
        builder.Property(p => p.Left).HasColumnName("Left").IsRequired();
        builder.Property(p => p.CreatedDate).HasColumnName("CreatedDate").IsRequired();
        builder.Property(p => p.UpdatedDate).HasColumnName("UpdatedDate");
        builder.Property(p => p.DeletedDate).HasColumnName("DeletedDate");
        builder.Property(p => p.LayerId).HasColumnName("LayerId").IsRequired();

        // One-to-One Relationship Configuration
        builder.HasOne(p => p.Layer).WithOne(l => l.Position).HasForeignKey<Position>(p => p.LayerId).OnDelete(DeleteBehavior.Cascade);

        builder.HasQueryFilter(p => !p.DeletedDate.HasValue);
    }
}