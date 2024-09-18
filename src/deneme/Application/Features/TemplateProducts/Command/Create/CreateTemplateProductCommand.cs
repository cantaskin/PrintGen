using Application.Features.Auth.Constants;
using Application.Features.OrderItems.Rules;
using Application.Features.Users.Rules;
using Application.Services.OrderItems;
using Application.Services.TemplateProducts;
using AutoMapper;
using Domain.Entities;
using NArchitecture.Core.Application.Pipelines.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.TemplateProducts.Command.Create;
public class CreateTemplateProductCommand : MediatR.IRequest<CreatedTemplateProductResponse> , ISecuredRequest
{
    public Guid OrderItemId { get; set; }
    public Guid UserId { get; set; }
    public string[] Roles  => [AuthOperationClaims.User];

    public class CreateTemplateProductCommandHandler : MediatR.IRequestHandler<CreateTemplateProductCommand, CreatedTemplateProductResponse>
    {
        private readonly IMapper _mapper;
        private readonly ITemplateProductService _templateProductService;
        private readonly IOrderItemService _orderItemService;
        private readonly OrderItemBusinessRules _orderItemBusinessRules;
        private readonly UserBusinessRules _userBusinessRules;
        public CreateTemplateProductCommandHandler(IMapper mapper, 
            IOrderItemService orderItemService,
            ITemplateProductService templateProductService, OrderItemBusinessRules orderItemBusinessRules, UserBusinessRules userBusinessRules)
        {
            _mapper = mapper;
            _orderItemService = orderItemService;
            _templateProductService = templateProductService;
            _orderItemBusinessRules = orderItemBusinessRules;
            _userBusinessRules = userBusinessRules;
        }

        public async Task<CreatedTemplateProductResponse> Handle(CreateTemplateProductCommand request, CancellationToken cancellationToken)
        {
            TemplateProduct templateProduct = _mapper.Map<TemplateProduct>(request);
            await _userBusinessRules.UserIdShouldBeExistsWhenSelected(request.UserId);
            await _orderItemBusinessRules.OrderItemIdShouldExistWhenSelected(request.OrderItemId,cancellationToken);


            OrderItem? orderItem = await _orderItemService.GetAsync(oi => oi.Id == request.OrderItemId);


            templateProduct.OrderItemId = orderItem.Id;


            await _templateProductService.AddAsync(templateProduct);
            
            //orderItem.TemplateProduct = templateProduct;

            await _orderItemService.UpdateAsync(orderItem);

            CreatedTemplateProductResponse createdTemplateProductResponse =
                _mapper.Map<CreatedTemplateProductResponse>(templateProduct);

            return createdTemplateProductResponse;
        }
    }
}
