using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfigurations;

public class AddressConfiguration : IEntityTypeConfiguration<Address>
{
    public void Configure(EntityTypeBuilder<Address> builder)
    {
        builder.ToTable("Addresses").HasKey(a => a.Id);

        builder.Property(a => a.Id).HasColumnName("Id").IsRequired();
        builder.Property(a => a.Name).HasColumnName("Name").IsRequired();
        builder.Property(a => a.Company).HasColumnName("Company").IsRequired();
        builder.Property(a => a.Address1).HasColumnName("Address1").IsRequired();
        builder.Property(a => a.Address2).HasColumnName("Address2").IsRequired();
        builder.Property(a => a.City).HasColumnName("City").IsRequired();
        builder.Property(a => a.StateCode).HasColumnName("StateCode").IsRequired();
        builder.Property(a => a.StateName).HasColumnName("StateName").IsRequired();
        builder.Property(a => a.CountryName).HasColumnName("CountryName").IsRequired();
        builder.Property(a => a.Zip).HasColumnName("Zip").IsRequired();
        builder.Property(a => a.Phone).HasColumnName("Phone").IsRequired();
        builder.Property(a => a.Email).HasColumnName("Email").IsRequired();
        builder.Property(a => a.TaxNumber).HasColumnName("TaxNumber");
        builder.Property(a => a.CreatedDate).HasColumnName("CreatedDate").IsRequired();
        builder.Property(a => a.UpdatedDate).HasColumnName("UpdatedDate");
        builder.Property(a => a.DeletedDate).HasColumnName("DeletedDate");

        builder.HasMany(a => a.Orders)
            .WithOne() 
            .HasForeignKey(o => o.AddressId);


        builder.HasQueryFilter(a => !a.DeletedDate.HasValue);
    }
}