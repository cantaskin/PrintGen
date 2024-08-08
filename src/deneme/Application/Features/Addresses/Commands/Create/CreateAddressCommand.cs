using Application.Features.Addresses.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.Addresses.Commands.Create;

public class CreateAddressCommand : IRequest<CreatedAddressResponse>
{
    public required string Name { get; set; }
    public required string Description { get; set; }
    public required Guid UserId { get; set; }

    public class CreateAddressCommandHandler : IRequestHandler<CreateAddressCommand, CreatedAddressResponse>
    {
        private readonly IMapper _mapper;
        private readonly IAddressRepository _addressRepository;
        private readonly AddressBusinessRules _addressBusinessRules;

        public CreateAddressCommandHandler(IMapper mapper, IAddressRepository addressRepository,
                                         AddressBusinessRules addressBusinessRules)
        {
            _mapper = mapper;
            _addressRepository = addressRepository;
            _addressBusinessRules = addressBusinessRules;
        }

        public async Task<CreatedAddressResponse> Handle(CreateAddressCommand request, CancellationToken cancellationToken)
        {
            Address address = _mapper.Map<Address>(request);

            await _addressRepository.AddAsync(address);

            CreatedAddressResponse response = _mapper.Map<CreatedAddressResponse>(address);
            return response;
        }
    }
}