using Application.Features.Auth.Constants;
using Application.Features.Users.Constants;
using Application.Features.Users.Rules;
using Application.Services.Repositories;
using Application.Services.TemplateProducts;
using Application.Services.UsersService;
using AutoMapper;
using Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Http;
using NArchitecture.Core.Application.Pipelines.Authorization;
using NArchitecture.Core.Security.Constants;

namespace Application.Features.Users.Queries.GetById;

public class GetByIdUserQuery :  ISecuredRequest, IRequest<GetByIdUserResponse>
{
    public Guid id { get; set; }

    public string[] Roles => [AuthOperationClaims.User];

    public class GetByIdUserQueryHandler : MediatR.IRequestHandler<GetByIdUserQuery, GetByIdUserResponse>
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
        private readonly UserBusinessRules _userBusinessRules;
        private readonly ITemplateProductService  _templateProductService;
        private readonly IUserService _userService;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public GetByIdUserQueryHandler(IUserRepository userRepository, IMapper mapper, UserBusinessRules userBusinessRules, ITemplateProductService templateProductService, IUserService userService, IHttpContextAccessor httpContextAccessor)
        {
            _userRepository = userRepository;
            _mapper = mapper;
            _userBusinessRules = userBusinessRules;
            _templateProductService = templateProductService;
            _userService = userService;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<GetByIdUserResponse> Handle(GetByIdUserQuery request, CancellationToken cancellationToken)
        {
            User? user = await _userRepository.GetAsync(
                predicate: b => b.Id.Equals(request.id),
                enableTracking: false,
                cancellationToken: cancellationToken
            );

            await _userBusinessRules.UserShouldBeExistsWhenSelected(user);
            var userId = await _userService.GetUserIdIntoAccessToken(_httpContextAccessor);
            var claim = await _userService.GetClaimAsync(_httpContextAccessor);
           

            var templateProducts = await _templateProductService.GetListAsync(tp => tp.UserId == user.Id);
            
            
            GetByIdUserResponse response = _mapper.Map<GetByIdUserResponse>(user);


            if (templateProducts?.Items != null)
                foreach (var templateProduct in templateProducts?.Items)
                {
                    response.templateProductsIds.Add(templateProduct.Id);
                }

            if(userId == user.Id || claim.Value.Equals(GeneralOperationClaims.Admin))
                return response;
            

            response.Email = null;
            response.PhoneNumber = null;
            return response;
        }
    }
}
