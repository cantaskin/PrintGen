using Domain.Entities;
using NArchitecture.Core.Application.Responses;

namespace Application.Features.Colors.Commands.Create;

public class CreatedColorResponse : IResponse
{
    public Guid Id { get; set; }
    public string ColorName { get; set; }
}