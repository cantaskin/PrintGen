using NArchitecture.Core.Application.Responses;

namespace Application.Features.PackingSlips.Queries.GetById;

public class GetByIdPackingSlipResponse : IResponse
{
    public Guid Id { get; set; }
    public string Email { get; set; }
    public string Phone { get; set; }
    public string Message { get; set; }
    public string LogoUrl { get; set; }
    public string StoreName { get; set; }
    public string CustomerOrderId { get; set; }
}