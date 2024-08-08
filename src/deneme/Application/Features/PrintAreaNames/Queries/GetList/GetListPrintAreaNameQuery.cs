using Application.Features.PrintAreaNames.Constants;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using NArchitecture.Core.Application.Pipelines.Authorization;
using NArchitecture.Core.Application.Pipelines.Caching;
using NArchitecture.Core.Application.Requests;
using NArchitecture.Core.Application.Responses;
using NArchitecture.Core.Persistence.Paging;
using MediatR;
using static Application.Features.PrintAreaNames.Constants.PrintAreaNamesOperationClaims;

namespace Application.Features.PrintAreaNames.Queries.GetList;

public class GetListPrintAreaNameQuery : IRequest<GetListResponse<GetListPrintAreaNameListItemDto>>, ISecuredRequest, ICachableRequest
{
    public PageRequest PageRequest { get; set; }

    public string[] Roles => [Admin, Read];

    public bool BypassCache { get; }
    public string? CacheKey => $"GetListPrintAreaNames({PageRequest.PageIndex},{PageRequest.PageSize})";
    public string? CacheGroupKey => "GetPrintAreaNames";
    public TimeSpan? SlidingExpiration { get; }

    public class GetListPrintAreaNameQueryHandler : IRequestHandler<GetListPrintAreaNameQuery, GetListResponse<GetListPrintAreaNameListItemDto>>
    {
        private readonly IPrintAreaNameRepository _printAreaNameRepository;
        private readonly IMapper _mapper;

        public GetListPrintAreaNameQueryHandler(IPrintAreaNameRepository printAreaNameRepository, IMapper mapper)
        {
            _printAreaNameRepository = printAreaNameRepository;
            _mapper = mapper;
        }

        public async Task<GetListResponse<GetListPrintAreaNameListItemDto>> Handle(GetListPrintAreaNameQuery request, CancellationToken cancellationToken)
        {
            IPaginate<PrintAreaName> printAreaNames = await _printAreaNameRepository.GetListAsync(
                index: request.PageRequest.PageIndex,
                size: request.PageRequest.PageSize, 
                cancellationToken: cancellationToken
            );

            GetListResponse<GetListPrintAreaNameListItemDto> response = _mapper.Map<GetListResponse<GetListPrintAreaNameListItemDto>>(printAreaNames);
            return response;
        }
    }
}