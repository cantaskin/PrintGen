using Application.Features.Auth.Constants;
using Application.Features.OrderItems.Rules;
using Application.Features.TemplateProducts.Rules;
using Application.Features.Users.Rules;
using Application.Services.TemplateProducts;
using AutoMapper;
using Domain.Entities;
using NArchitecture.Core.Application.Pipelines.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.TemplateProducts.Command.Update;
public class UpdateTemplateProductCommand : MediatR.IRequest<UpdatedTemplateProductResponse> , ISecuredRequest
{
    public Guid Id { get; set; }
    public Guid OrderItemId { get; set; }
    public Guid UserId { get; set; }
    public string[] Roles => [AuthOperationClaims.User];

    public class UpdateTemplateProductHandler : MediatR.IRequestHandler<UpdateTemplateProductCommand,
        UpdatedTemplateProductResponse>
    {
        private readonly IMapper _mapper;
        private readonly UserBusinessRules _userBusinessRules;
        private readonly OrderItemBusinessRules _orderItemBusinessRules;
        private readonly ITemplateProductService _templateProductService;
        private readonly TemplateProductBusinessRules _templateProductBusinessRules;

        public UpdateTemplateProductHandler(IMapper mapper, UserBusinessRules userBusinessRules, OrderItemBusinessRules orderItemBusinessRules, ITemplateProductService templateProductService, TemplateProductBusinessRules templateProductBusinessRules)
        {
            _mapper = mapper;
            _userBusinessRules = userBusinessRules;
            _orderItemBusinessRules = orderItemBusinessRules;
            _templateProductService = templateProductService;
            _templateProductBusinessRules = templateProductBusinessRules;
        }
        public async Task<UpdatedTemplateProductResponse> Handle(UpdateTemplateProductCommand request, CancellationToken cancellationToken)
        {
            TemplateProduct templateProduct = _mapper.Map<TemplateProduct>(request);
            await _templateProductBusinessRules.TemplateProductIdShouldExistWhenSelected(request.Id, cancellationToken);
             await _userBusinessRules.UserIdShouldBeExistsWhenSelected(request.UserId);
             await _orderItemBusinessRules.OrderItemIdShouldExistWhenSelected(request.OrderItemId,cancellationToken);


             await _templateProductService.UpdateAsync(templateProduct);
            
             UpdatedTemplateProductResponse updatedTemplateProductResponse =
                 _mapper.Map<UpdatedTemplateProductResponse>(templateProduct);
             return updatedTemplateProductResponse;
        }
    }
}
