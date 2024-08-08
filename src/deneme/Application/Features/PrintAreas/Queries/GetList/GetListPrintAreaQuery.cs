using Application.Features.PrintAreas.Constants;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using NArchitecture.Core.Application.Pipelines.Authorization;
using NArchitecture.Core.Application.Pipelines.Caching;
using NArchitecture.Core.Application.Requests;
using NArchitecture.Core.Application.Responses;
using NArchitecture.Core.Persistence.Paging;
using MediatR;
using static Application.Features.PrintAreas.Constants.PrintAreasOperationClaims;

namespace Application.Features.PrintAreas.Queries.GetList;

public class GetListPrintAreaQuery : IRequest<GetListResponse<GetListPrintAreaListItemDto>>, ISecuredRequest, ICachableRequest
{
    public PageRequest PageRequest { get; set; }

    public string[] Roles => [Admin, Read];

    public bool BypassCache { get; }
    public string? CacheKey => $"GetListPrintAreas({PageRequest.PageIndex},{PageRequest.PageSize})";
    public string? CacheGroupKey => "GetPrintAreas";
    public TimeSpan? SlidingExpiration { get; }

    public class GetListPrintAreaQueryHandler : IRequestHandler<GetListPrintAreaQuery, GetListResponse<GetListPrintAreaListItemDto>>
    {
        private readonly IPrintAreaRepository _printAreaRepository;
        private readonly IMapper _mapper;

        public GetListPrintAreaQueryHandler(IPrintAreaRepository printAreaRepository, IMapper mapper)
        {
            _printAreaRepository = printAreaRepository;
            _mapper = mapper;
        }

        public async Task<GetListResponse<GetListPrintAreaListItemDto>> Handle(GetListPrintAreaQuery request, CancellationToken cancellationToken)
        {
            IPaginate<PrintArea> printAreas = await _printAreaRepository.GetListAsync(
                index: request.PageRequest.PageIndex,
                size: request.PageRequest.PageSize, 
                cancellationToken: cancellationToken
            );

            GetListResponse<GetListPrintAreaListItemDto> response = _mapper.Map<GetListResponse<GetListPrintAreaListItemDto>>(printAreas);
            return response;
        }
    }
}