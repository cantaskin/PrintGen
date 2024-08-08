using Application.Features.Addresses.Constants;
using Application.Features.Addresses.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.Addresses.Commands.Delete;

public class DeleteAddressCommand : IRequest<DeletedAddressResponse>
{
    public Guid Id { get; set; }

    public class DeleteAddressCommandHandler : IRequestHandler<DeleteAddressCommand, DeletedAddressResponse>
    {
        private readonly IMapper _mapper;
        private readonly IAddressRepository _addressRepository;
        private readonly AddressBusinessRules _addressBusinessRules;

        public DeleteAddressCommandHandler(IMapper mapper, IAddressRepository addressRepository,
                                         AddressBusinessRules addressBusinessRules)
        {
            _mapper = mapper;
            _addressRepository = addressRepository;
            _addressBusinessRules = addressBusinessRules;
        }

        public async Task<DeletedAddressResponse> Handle(DeleteAddressCommand request, CancellationToken cancellationToken)
        {
            Address? address = await _addressRepository.GetAsync(predicate: a => a.Id == request.Id, cancellationToken: cancellationToken);
            await _addressBusinessRules.AddressShouldExistWhenSelected(address);

            await _addressRepository.DeleteAsync(address!);

            DeletedAddressResponse response = _mapper.Map<DeletedAddressResponse>(address);
            return response;
        }
    }
}