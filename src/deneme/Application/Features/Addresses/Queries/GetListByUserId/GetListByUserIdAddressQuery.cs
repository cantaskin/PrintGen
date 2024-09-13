using Application.Features.Addresses.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using NArchitecture.Core.Application.Requests;
using NArchitecture.Core.Application.Responses;
using NArchitecture.Core.Persistence.Paging;
using MediatR;
using NArchitecture.Core.Application.Pipelines.Authorization;
using Application.Features.Auth.Constants;
using Application.Features.Users.Rules;
using Application.Services.UsersService;
using Microsoft.AspNetCore.Http;
using NArchitecture.Core.Security.Constants;
using System.Security.Claims;

namespace Application.Features.Addresses.Queries.GetListbyUserId;

public class GetListByUserIdAddressQuery : IRequest<GetListResponse<GetListByUserIdAddressListItemDto>>, ISecuredRequest
{
    public PageRequest PageRequest { get; set; }

    public Guid Id { get; set; }

    public string[] Roles => [AuthOperationClaims.User];

    public class GetListAddressQueryHandler : IRequestHandler<GetListByUserIdAddressQuery, GetListResponse<GetListByUserIdAddressListItemDto>>
    {
        private readonly IAddressRepository _addressRepository;
        private readonly IMapper _mapper;
        private readonly IUserService _userService;

        public GetListAddressQueryHandler(IAddressRepository addressRepository, IMapper mapper, IUserService userService)
        {
            _addressRepository = addressRepository;
            _mapper = mapper;
            _userService = userService;
        }

        public async Task<GetListResponse<GetListByUserIdAddressListItemDto>> Handle(GetListByUserIdAddressQuery request, CancellationToken cancellationToken)
        {
            IPaginate<Address> addresses = await _addressRepository.GetListAsync(
                predicate: address => address.UserId == request.Id,
                index: request.PageRequest.PageIndex,
                size: request.PageRequest.PageSize, 
                cancellationToken: cancellationToken
            );


            await _userService.EnsureAdminOrUserOwnership(request.Id);

            GetListResponse<GetListByUserIdAddressListItemDto> response = _mapper.Map<GetListResponse<GetListByUserIdAddressListItemDto>>(addresses);
            return response;
        }
    }
}