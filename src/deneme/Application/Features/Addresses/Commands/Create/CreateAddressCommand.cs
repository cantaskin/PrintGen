using Application.Features.Addresses.Rules;
using Application.Features.Auth.Constants;
using Application.Services.Repositories;
using Application.Services.UsersService;
using AutoMapper;
using Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Http;
using NArchitecture.Core.Application.Pipelines.Authorization;
using Microsoft.AspNetCore.Http;
using Nest;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace Application.Features.Addresses.Commands.Create;

public class CreateAddressCommand : MediatR.IRequest<CreatedAddressResponse>, ISecuredRequest
{
    public required string Name { get; set; }
    public required string Company { get; set; }
    public required string Address1 { get; set; }
    public required string Address2 { get; set; }
    public required string City { get; set; }
    public required string StateCode { get; set; }
    public required string StateName { get; set; }
    public required string CountryName { get; set; }
    public required string CountryCode { get; set; }
    public required string Zip { get; set; }
    public required string Phone { get; set; }
    public required string Email { get; set; }
    public string? TaxNumber { get; set; }

    public string[] Roles => [AuthOperationClaims.User];

    public class CreateAddressCommandHandler : IRequestHandler<CreateAddressCommand, CreatedAddressResponse>
    {
        private readonly IMapper _mapper;
        private readonly IAddressRepository _addressRepository;
        private readonly AddressBusinessRules _addressBusinessRules;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IUserService _userService;

        public CreateAddressCommandHandler(IMapper mapper, IAddressRepository addressRepository,
                                         AddressBusinessRules addressBusinessRules, IHttpContextAccessor httpContextAccessor, IUserService userService)
        {
            _mapper = mapper;
            _addressRepository = addressRepository;
            _addressBusinessRules = addressBusinessRules;
            _httpContextAccessor = httpContextAccessor;
            _userService = userService;
        }

        public async Task<CreatedAddressResponse> Handle(CreateAddressCommand request, CancellationToken cancellationToken)
        {
            Address address = _mapper.Map<Address>(request);

            address.UserId = await _userService.GetUserIdIntoAccessToken(_httpContextAccessor);

            await _addressRepository.AddAsync(address);

            CreatedAddressResponse response = _mapper.Map<CreatedAddressResponse>(address);
            return response;
        }
    }
}