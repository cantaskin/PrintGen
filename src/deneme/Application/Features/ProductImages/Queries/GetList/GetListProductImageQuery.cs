using Application.Features.ProductImages.Constants;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using NArchitecture.Core.Application.Pipelines.Authorization;
using NArchitecture.Core.Application.Pipelines.Caching;
using NArchitecture.Core.Application.Requests;
using NArchitecture.Core.Application.Responses;
using NArchitecture.Core.Persistence.Paging;
using MediatR;
using static Application.Features.ProductImages.Constants.ProductImagesOperationClaims;

namespace Application.Features.ProductImages.Queries.GetList;

public class GetListProductImageQuery : IRequest<GetListResponse<GetListProductImageListItemDto>>, ISecuredRequest, ICachableRequest
{
    public PageRequest PageRequest { get; set; }

    public string[] Roles => [Admin, Read];

    public bool BypassCache { get; }
    public string? CacheKey => $"GetListProductImages({PageRequest.PageIndex},{PageRequest.PageSize})";
    public string? CacheGroupKey => "GetProductImages";
    public TimeSpan? SlidingExpiration { get; }

    public class GetListProductImageQueryHandler : IRequestHandler<GetListProductImageQuery, GetListResponse<GetListProductImageListItemDto>>
    {
        private readonly IProductImageRepository _productImageRepository;
        private readonly IMapper _mapper;

        public GetListProductImageQueryHandler(IProductImageRepository productImageRepository, IMapper mapper)
        {
            _productImageRepository = productImageRepository;
            _mapper = mapper;
        }

        public async Task<GetListResponse<GetListProductImageListItemDto>> Handle(GetListProductImageQuery request, CancellationToken cancellationToken)
        {
            IPaginate<ProductImage> productImages = await _productImageRepository.GetListAsync(
                index: request.PageRequest.PageIndex,
                size: request.PageRequest.PageSize, 
                cancellationToken: cancellationToken
            );

            GetListResponse<GetListProductImageListItemDto> response = _mapper.Map<GetListResponse<GetListProductImageListItemDto>>(productImages);
            return response;
        }
    }
}