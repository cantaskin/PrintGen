namespace Domain.Entities;

public class User : NArchitecture.Core.Security.Entities.User<Guid>
{

    public string NickName { get; set; }
    public string PhoneNumber { get; set; }

    //Profil fotosu için yeni bir entity oluştur.
    public virtual ICollection<UserOperationClaim> UserOperationClaims { get; set; } = default!;
    public virtual ICollection<RefreshToken> RefreshTokens { get; set; } = default!;
    public virtual ICollection<OtpAuthenticator> OtpAuthenticators { get; set; } = default!;
    public virtual ICollection<EmailAuthenticator> EmailAuthenticators { get; set; } = default!;

    public virtual ICollection<Prompt> Prompts { get; set; } = default!;

    public virtual ICollection<CustomizedImage> CustomizedImages { get; set; } = default!;

}
