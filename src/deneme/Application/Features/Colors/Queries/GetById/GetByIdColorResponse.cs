using NArchitecture.Core.Application.Responses;

namespace Application.Features.Colors.Queries.GetById;

public class GetByIdColorResponse : IResponse
{
    public Guid Id { get; set; }
    public string ColorName { get; set; }
}