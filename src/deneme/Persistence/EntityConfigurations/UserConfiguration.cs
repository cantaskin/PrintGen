using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NArchitecture.Core.Security.Hashing;
using Nest;

namespace Persistence.EntityConfigurations;

public class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.ToTable("Users").HasKey(u => u.Id);

        builder.Property(u => u.Id).HasColumnName("Id").IsRequired();
        builder.Property(u => u.Email).HasColumnName("Email").IsRequired();
        builder.Property(u => u.PasswordSalt).HasColumnName("PasswordSalt").IsRequired();
        builder.Property(u => u.PasswordHash).HasColumnName("PasswordHash").IsRequired();
        builder.Property(u => u.AuthenticatorType).HasColumnName("AuthenticatorType").IsRequired();
        builder.Property(u => u.CreatedDate).HasColumnName("CreatedDate").IsRequired();
        builder.Property(u => u.UpdatedDate).HasColumnName("UpdatedDate");
        builder.Property(u => u.DeletedDate).HasColumnName("DeletedDate");
        builder.Property(u => u.UserName).HasColumnName("UserName").IsRequired();
        builder.Property(u => u.PhoneNumber).HasColumnName("PhoneNumber").IsRequired();
        builder.Property(u => u.FirstName).HasColumnName("FirstName").IsRequired();
        builder.Property(u => u.LastName).HasColumnName("LastName").IsRequired();


    builder.HasQueryFilter(u => !u.DeletedDate.HasValue);

        builder.HasMany(u => u.UserOperationClaims);
        builder.HasMany(u => u.RefreshTokens);
        builder.HasMany(u => u.EmailAuthenticators);
        builder.HasMany(u => u.OtpAuthenticators);
        builder.HasMany(u => u.CustomizedImages);
        builder.HasMany(u => u.Prompts);
        builder.HasMany(u => u.Orders);
        builder.HasMany(u => u.TemplateProducts);
        builder.HasMany(u => u.Address);

        builder.HasData(_seeds);

        builder.HasBaseType((string)null!);
    }

    public static Guid AdminId { get; } = new Guid("15b9521a-ba70-4658-98f1-aa7942d5a2ec");
    private IEnumerable<User> _seeds
    {
        get
        {
            HashingHelper.CreatePasswordHash(
                password: "Tasarim159.",
                passwordHash: out byte[] passwordHash,
                passwordSalt: out byte[] passwordSalt
            );
            User adminUser =
                new()
                {
                    Id = AdminId,
                    FirstName = "Mahmut",
                    LastName = "Tuncer",
                    Email = "myCrazyip@proton.me",
                    PasswordHash = passwordHash,
                    PasswordSalt = passwordSalt,
                    UserName = "Deneme",
                    PhoneNumber = "+9012354353"
                };
            yield return adminUser;
        }
    }
}
