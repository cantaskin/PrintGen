using Application.Features.CustomizedImages.Constants;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using NArchitecture.Core.Application.Pipelines.Authorization;
using NArchitecture.Core.Application.Pipelines.Caching;
using NArchitecture.Core.Application.Requests;
using NArchitecture.Core.Application.Responses;
using NArchitecture.Core.Persistence.Paging;
using MediatR;
using static Application.Features.CustomizedImages.Constants.CustomizedImagesOperationClaims;

namespace Application.Features.CustomizedImages.Queries.GetList;

public class GetListCustomizedImageQuery : IRequest<GetListResponse<GetListCustomizedImageListItemDto>>, ISecuredRequest, ICachableRequest
{
    public PageRequest PageRequest { get; set; }

    public string[] Roles => [Admin, Read];

    public bool BypassCache { get; }
    public string? CacheKey => $"GetListCustomizedImages({PageRequest.PageIndex},{PageRequest.PageSize})";
    public string? CacheGroupKey => "GetCustomizedImages";
    public TimeSpan? SlidingExpiration { get; }

    public class GetListCustomizedImageQueryHandler : IRequestHandler<GetListCustomizedImageQuery, GetListResponse<GetListCustomizedImageListItemDto>>
    {
        private readonly ICustomizedImageRepository _customizedImageRepository;
        private readonly IMapper _mapper;

        public GetListCustomizedImageQueryHandler(ICustomizedImageRepository customizedImageRepository, IMapper mapper)
        {
            _customizedImageRepository = customizedImageRepository;
            _mapper = mapper;
        }

        public async Task<GetListResponse<GetListCustomizedImageListItemDto>> Handle(GetListCustomizedImageQuery request, CancellationToken cancellationToken)
        {
            IPaginate<CustomizedImage> customizedImages = await _customizedImageRepository.GetListAsync(
                index: request.PageRequest.PageIndex,
                size: request.PageRequest.PageSize, 
                cancellationToken: cancellationToken
            );

            GetListResponse<GetListCustomizedImageListItemDto> response = _mapper.Map<GetListResponse<GetListCustomizedImageListItemDto>>(customizedImages);
            return response;
        }
    }
}