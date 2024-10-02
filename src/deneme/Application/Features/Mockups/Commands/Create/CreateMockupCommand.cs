using Application.Features.Addresses.Commands.Create;
using Application.Features.Auth.Constants;
using Application.Services.PrintfulService;
using Application.Services.PrintOnDemand;
using Application.Services.Repositories;
using Application.Services.UsersService;
using AutoMapper;
using Domain.DTO;
using Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Http;
using NArchitecture.Core.Application.Pipelines.Authorization;

namespace Application.Features.Mockups.Commands.Create;

public class CreateMockupCommand : MediatR.IRequest<CreatedMockupResponse>, ISecuredRequest
{
    public MockupDto Mockup { get; set; }

    public string[] Roles => [AuthOperationClaims.User];

    public class CreateMockupCommandHandler : IRequestHandler<CreateMockupCommand, CreatedMockupResponse>
    {
        private readonly PrintfulServiceBase _printfulServiceAdapter;
        private readonly IMapper _mapper;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IUserService _userService;

        public CreateMockupCommandHandler(IMapper mapper, IHttpContextAccessor httpContextAccessor, IUserService userService, PrintfulServiceBase printfulServiceAdapter)
        {
            _mapper = mapper;
            _httpContextAccessor = httpContextAccessor;
            _userService = userService;
            _printfulServiceAdapter = printfulServiceAdapter;
        }

        public async Task<CreatedMockupResponse> Handle(CreateMockupCommand request, CancellationToken cancellationToken)
        {

            await _userService.GetUserIdIntoAccessToken(_httpContextAccessor);
            var content  = await _printfulServiceAdapter.CreateMockupAsync(request.Mockup);

            return new CreatedMockupResponse() { Response = content };
        }
    }
}