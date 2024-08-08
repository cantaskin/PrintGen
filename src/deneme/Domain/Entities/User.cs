﻿namespace Domain.Entities;

public class User : NArchitecture.Core.Security.Entities.User<Guid>
{
    public virtual ICollection<UserOperationClaim> UserOperationClaims { get; set; } = default!;
    public virtual ICollection<RefreshToken> RefreshTokens { get; set; } = default!;
    public virtual ICollection<OtpAuthenticator> OtpAuthenticators { get; set; } = default!;
    public virtual ICollection<EmailAuthenticator> EmailAuthenticators { get; set; } = default!;
    public virtual ICollection<CustomizedProduct>? CustomizedProducts { get; set; } = default;
    public virtual  ICollection<Order> Orders { get; set; }
    public virtual ICollection<Address>? Addresses { get; set; } = default;
}
