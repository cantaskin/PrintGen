using Application.Features.Auth.Constants;
using Application.Features.Orders.Rules;
using Application.Features.Users.Rules;
using Application.Services.Repositories;
using Application.Services.UsersService;
using AutoMapper;
using Domain.Entities;
using NArchitecture.Core.Application.Requests;
using NArchitecture.Core.Application.Responses;
using NArchitecture.Core.Persistence.Paging;
using MediatR;
using Microsoft.EntityFrameworkCore;
using NArchitecture.Core.Application.Pipelines.Authorization;

namespace Application.Features.Orders.Queries.GetListbyUserId;

public class GetListbyUserIdOrderQuery : IRequest<GetListResponse<GetListbyUserIdOrderListItemDto>> , ISecuredRequest
{
    public PageRequest PageRequest { get; set; }

    public Guid UserId { get; set; }

    public string[] Roles  => [AuthOperationClaims.User];

    public class GetListOrderQueryHandler : IRequestHandler<GetListbyUserIdOrderQuery, GetListResponse<GetListbyUserIdOrderListItemDto>>
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IMapper _mapper;
        private readonly IUserService _userService;
        public GetListOrderQueryHandler(IOrderRepository orderRepository, IMapper mapper, IUserService userService)
        {
            _orderRepository = orderRepository;
            _mapper = mapper;
            _userService = userService;
        }

        public async Task<GetListResponse<GetListbyUserIdOrderListItemDto>> Handle(GetListbyUserIdOrderQuery request, CancellationToken cancellationToken)
        {
            IPaginate<Order> orders = await _orderRepository.GetListAsync(
                predicate: o => o.UserId == request.UserId,
              //  include: o => o
                  //  .Include(order => order.OrderItems)
                   // .ThenInclude(orderItem => orderItem.Placements)
                   // .ThenInclude(p => p.Layers)
                    //.ThenInclude(l => l.Position)
                   // .Include(order => order.Customization),
                index: request.PageRequest.PageIndex,
                size: request.PageRequest.PageSize, 
                cancellationToken: cancellationToken
            );

           await _userService.EnsureAdminOrUserOwnership(request.UserId);

            GetListResponse<GetListbyUserIdOrderListItemDto> response = _mapper.Map<GetListResponse<GetListbyUserIdOrderListItemDto>>(orders);
            return response;
        }
    }

   
}