using NArchitecture.Core.Application.Responses;

namespace Application.Features.Addresses.Commands.Create;

public class CreatedAddressResponse : IResponse
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Company { get; set; }
    public string Address1 { get; set; }
    public string Address2 { get; set; }
    public string City { get; set; }
    public string StateCode { get; set; }
    public string StateName { get; set; }
    public string CountryName { get; set; }
    public string Zip { get; set; }
    public string Phone { get; set; }
    public string Email { get; set; }
    public string? TaxNumber { get; set; }
}