using Application.Features.Addresses.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.Addresses.Commands.Update;

public class UpdateAddressCommand : IRequest<UpdatedAddressResponse>
{
    public Guid Id { get; set; }
    public required string Name { get; set; }
    public required string Description { get; set; }
    public required Guid UserId { get; set; }

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