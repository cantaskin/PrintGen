using Domain.Entities;
using NArchitecture.Core.Application.Responses;

namespace Application.Features.Customizations.Commands.Update;

public class UpdatedCustomizationResponse : IResponse
{
    public Guid Id { get; set; }
    public Guid? GiftId { get; set; }
    public Guid PackingSlipId { get; set; }
}