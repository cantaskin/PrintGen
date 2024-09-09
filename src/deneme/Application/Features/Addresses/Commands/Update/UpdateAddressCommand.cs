using Application.Features.Addresses.Rules;
using Application.Features.Auth.Constants;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;
using NArchitecture.Core.Application.Pipelines.Authorization;

namespace Application.Features.Addresses.Commands.Update;

public class UpdateAddressCommand : IRequest<UpdatedAddressResponse>, ISecuredRequest
{
    public Guid Id { get; set; }
    public required string Name { get; set; }
    public required string Company { get; set; }
    public required string Address1 { get; set; }
    public required string Address2 { get; set; }
    public required string City { get; set; }
    public required string StateCode { get; set; }
    public required string StateName { get; set; }
    public required string CountryName { get; set; }
    public required string Zip { get; set; }
    public required string Phone { get; set; }
    public required string Email { get; set; }
    public string? TaxNumber { get; set; }

    public string[] Roles => [];

    public class UpdateAddressCommandHandler : IRequestHandler<UpdateAddressCommand, UpdatedAddressResponse>
    {
        private readonly IMapper _mapper;
        private readonly IAddressRepository _addressRepository;
        private readonly AddressBusinessRules _addressBusinessRules;

        public UpdateAddressCommandHandler(IMapper mapper, IAddressRepository addressRepository,
                                         AddressBusinessRules addressBusinessRules)
        {
            _mapper = mapper;
            _addressRepository = addressRepository;
            _addressBusinessRules = addressBusinessRules;
        }

        public async Task<UpdatedAddressResponse> Handle(UpdateAddressCommand request, CancellationToken cancellationToken)
        {
            Address? address = await _addressRepository.GetAsync(predicate: a => a.Id == request.Id, cancellationToken: cancellationToken);
            await _addressBusinessRules.AddressShouldExistWhenSelected(address);
            address = _mapper.Map(request, address);

            await _addressRepository.UpdateAsync(address!);

            UpdatedAddressResponse response = _mapper.Map<UpdatedAddressResponse>(address);
            return response;
        }
    }
}