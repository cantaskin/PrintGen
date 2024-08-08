using Application.Features.CustomizedProducts.Constants;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using NArchitecture.Core.Application.Pipelines.Authorization;
using NArchitecture.Core.Application.Pipelines.Caching;
using NArchitecture.Core.Application.Requests;
using NArchitecture.Core.Application.Responses;
using NArchitecture.Core.Persistence.Paging;
using MediatR;
using static Application.Features.CustomizedProducts.Constants.CustomizedProductsOperationClaims;

namespace Application.Features.CustomizedProducts.Queries.GetList;

public class GetListCustomizedProductQuery : IRequest<GetListResponse<GetListCustomizedProductListItemDto>>, ISecuredRequest, ICachableRequest
{
    public PageRequest PageRequest { get; set; }

    public string[] Roles => [Admin, Read];

    public bool BypassCache { get; }
    public string? CacheKey => $"GetListCustomizedProducts({PageRequest.PageIndex},{PageRequest.PageSize})";
    public string? CacheGroupKey => "GetCustomizedProducts";
    public TimeSpan? SlidingExpiration { get; }

    public class GetListCustomizedProductQueryHandler : IRequestHandler<GetListCustomizedProductQuery, GetListResponse<GetListCustomizedProductListItemDto>>
    {
        private readonly ICustomizedProductRepository _customizedProductRepository;
        private readonly IMapper _mapper;

        public GetListCustomizedProductQueryHandler(ICustomizedProductRepository customizedProductRepository, IMapper mapper)
        {
            _customizedProductRepository = customizedProductRepository;
            _mapper = mapper;
        }

        public async Task<GetListResponse<GetListCustomizedProductListItemDto>> Handle(GetListCustomizedProductQuery request, CancellationToken cancellationToken)
        {
            IPaginate<CustomizedProduct> customizedProducts = await _customizedProductRepository.GetListAsync(
                index: request.PageRequest.PageIndex,
                size: request.PageRequest.PageSize, 
                cancellationToken: cancellationToken
            );

            GetListResponse<GetListCustomizedProductListItemDto> response = _mapper.Map<GetListResponse<GetListCustomizedProductListItemDto>>(customizedProducts);
            return response;
        }
    }
}