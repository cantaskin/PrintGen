using NArchitecture.Core.Application.Responses;

namespace Application.Features.Users.Queries.GetById;

public class GetByIdUserResponse : IResponse
{
    public Guid Id { get; set; }

    public string UserName { get; set; }

    public string? FirstName { get; set; }

    public string? LastName { get; set; }
    public string? PhoneNumber { get; set; }
    public string? Email { get; set; }

    //Profil foto ve template products

    public List<Guid>? templateProductsIds { get; set; }


    public GetByIdUserResponse(string? firstName, string? lastName, string? phoneNumber)
    {
        FirstName = firstName;
        LastName = lastName;
        PhoneNumber = phoneNumber;
        UserName = string.Empty;
    }

    public GetByIdUserResponse(Guid id, string UserName, string phoneNumber, string lastName, string firstName, string? firstName1, string? lastName1, string? phoneNumber1)
    {
        Id = id;
        FirstName = firstName1;
        LastName = lastName1;
        PhoneNumber = phoneNumber1;
        UserName = UserName;
    }
}
