using Domain.Entities;
using NArchitecture.Core.Application.Responses;

namespace Application.Features.Colors.Commands.Update;

public class UpdatedColorResponse : IResponse
{
    public Guid Id { get; set; }
    public string ColorName { get; set; }
}