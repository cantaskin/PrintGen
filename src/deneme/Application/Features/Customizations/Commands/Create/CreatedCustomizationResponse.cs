using Domain.Entities;
using NArchitecture.Core.Application.Responses;

namespace Application.Features.Customizations.Commands.Create;

public class CreatedCustomizationResponse : IResponse
{
    public Guid Id { get; set; }
    public Guid? GiftId { get; set; }
    public Gift? Gift { get; set; }
    public Guid PackingSlipId { get; set; }
    public PackingSlip PackingSlip { get; set; }
}