using NArchitecture.Core.Application.Responses;

namespace Application.Features.Users.Queries.GetById;

public class GetByIdUserResponse : IResponse
{
    public Guid Id { get; set; }

    public string NickName { get; set; }

    public string PhoneNumber { get; set; }
    public string Email { get; set; }

    public GetByIdUserResponse()
    {
        PhoneNumber = string.Empty;
        NickName = string.Empty;
        Email = string.Empty;
    }

    public GetByIdUserResponse(Guid id, string nickName, string phoneNumber, string email)
    {
        Id = id;
        NickName = nickName;
        PhoneNumber = phoneNumber;
        Email = email;
    }
}
