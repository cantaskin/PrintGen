using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.Extensions.Configuration;

namespace Persistence.EntityConfigurations;

public class PackingSlipConfiguration : IEntityTypeConfiguration<PackingSlip>
{
    public void Configure(EntityTypeBuilder<PackingSlip> builder)
    {
        builder.ToTable("PackingSlips").HasKey(ps => ps.Id);

        builder.Property(ps => ps.Id).HasColumnName("Id").IsRequired();
        builder.Property(ps => ps.Email).HasColumnName("Email").IsRequired();
        builder.Property(ps => ps.Phone).HasColumnName("Phone").IsRequired();
        builder.Property(ps => ps.Message).HasColumnName("Message").IsRequired();
        builder.Property(ps => ps.LogoUrl).HasColumnName("LogoUrl").IsRequired();
        builder.Property(ps => ps.StoreName).HasColumnName("StoreName").IsRequired();
        builder.Property(ps => ps.CreatedDate).HasColumnName("CreatedDate").IsRequired();
        builder.Property(ps => ps.UpdatedDate).HasColumnName("UpdatedDate");
        builder.Property(ps => ps.DeletedDate).HasColumnName("DeletedDate");

        builder.HasData(_seeds);

        builder.HasMany(p => p.Customizations)
            .WithOne(c => c.PackingSlip)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasQueryFilter(ps => !ps.DeletedDate.HasValue);
    }

    private IEnumerable<PackingSlip> _seeds
    {
        get
        {

            PackingSlip packingSlip =
                new PackingSlip()
                {
                    Email = "myCrazyip@proton.me",
                    Id = new Guid("043a460f-03fe-4811-9197-5326286519c6"),
                    LogoUrl =
                        "https://upload.wikimedia.org/wikipedia/commons/8/8d/42_Logo.svg",
                    Phone = "+905432133422",
                    StoreName = "Deneme",
                    CreatedDate = DateTime.Now,
                    Message = "Made by Deneme"
                };
            yield return packingSlip;
        }
    }
}