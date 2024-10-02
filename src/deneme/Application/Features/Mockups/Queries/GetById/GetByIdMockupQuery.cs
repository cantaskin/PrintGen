using Application.Features.Addresses.Queries.GetById;
using Application.Features.Auth.Constants;
using Application.Services.PrintfulService;
using Application.Services.UsersService;
using AutoMapper;
using Domain.Entities;
using MediatR;
using NArchitecture.Core.Application.Pipelines.Authorization;
using Nest;

namespace Application.Features.Mockups.Queries.GetById;

public class GetByIdMockupQuery : MediatR.IRequest<GetByIdMockupResponse>, ISecuredRequest
{
    public string Id { get; set; }

    public Guid UserId { get; set; }

    public string[] Roles => [AuthOperationClaims.User];
    public class GetByIdMockupQueryHandler : IRequestHandler<GetByIdMockupQuery, GetByIdMockupResponse>
    {
        private readonly IMapper _mapper;
        private readonly IUserService _userService;
        private readonly PrintfulServiceBase _printfulService;
        public GetByIdMockupQueryHandler(IMapper mapper,IUserService userService, PrintfulServiceBase printfulService)
        {
            _mapper = mapper;
            _userService = userService;
            _printfulService = printfulService;
        }

        public async Task<GetByIdMockupResponse> Handle(GetByIdMockupQuery request, CancellationToken cancellationToken)
        {
            await _userService.EnsureAdminOrUserOwnership(request.UserId);

            
            var response = await _printfulService.GetMockupAsync(request.Id);
            return new GetByIdMockupResponse() {Response = response};
        }
    }
}