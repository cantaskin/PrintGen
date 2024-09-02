using NArchitecture.Core.Application.Responses;

namespace Application.Features.PackingSlips.Commands.Create;

public class CreatedPackingSlipResponse : IResponse
{
    public Guid Id { get; set; }
    public string Email { get; set; }
    public string Phone { get; set; }
    public string Message { get; set; }
    public string LogoUrl { get; set; }
    public string StoreName { get; set; }
    public string CustomerOrderId { get; set; }
}