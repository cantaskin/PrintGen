using Application.Features.Addresses.Rules;
using Application.Features.Auth.Constants;
using Application.Features.Users.Rules;
using Application.Services.Repositories;
using Application.Services.UsersService;
using AutoMapper;
using Domain.Entities;
using MediatR;
using NArchitecture.Core.Application.Pipelines.Authorization;

namespace Application.Features.Addresses.Queries.GetById;

public class GetByIdAddressQuery : IRequest<GetByIdAddressResponse>, ISecuredRequest
{
    public Guid Id { get; set; }

    public Guid UserId { get; set; }

    public string[] Roles => [AuthOperationClaims.User];
    public class GetByIdAddressQueryHandler : IRequestHandler<GetByIdAddressQuery, GetByIdAddressResponse>
    {
        private readonly IMapper _mapper;
        private readonly IAddressRepository _addressRepository;
        private readonly IUserService _userService;
        private readonly AddressBusinessRules _addressBusinessRules;

        public GetByIdAddressQueryHandler(IMapper mapper, IAddressRepository addressRepository, AddressBusinessRules addressBusinessRules, IUserService userService)
        {
            _mapper = mapper;
            _addressRepository = addressRepository;
            _addressBusinessRules = addressBusinessRules;
            _userService = userService;
        }

        public async Task<GetByIdAddressResponse> Handle(GetByIdAddressQuery request, CancellationToken cancellationToken)
        {
            Address? address = await _addressRepository.GetAsync(predicate: a => a.Id == request.Id, cancellationToken: cancellationToken);
            await _addressBusinessRules.AddressShouldExistWhenSelected(address);

            await _userService.EnsureAdminOrUserOwnership(request.UserId);

            GetByIdAddressResponse response = _mapper.Map<GetByIdAddressResponse>(address);
            return response;
        }
    }
}