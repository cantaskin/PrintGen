using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using NArchitecture.Core.Application.Requests;
using NArchitecture.Core.Application.Responses;
using NArchitecture.Core.Persistence.Paging;
using MediatR;

namespace Application.Features.RetailCosts.Queries.GetList;

public class GetListRetailCostQuery : IRequest<GetListResponse<GetListRetailCostListItemDto>>
{
    public PageRequest PageRequest { get; set; }

    public class GetListRetailCostQueryHandler : IRequestHandler<GetListRetailCostQuery, GetListResponse<GetListRetailCostListItemDto>>
    {
        private readonly IRetailCostRepository _retailCostRepository;
        private readonly IMapper _mapper;

        public GetListRetailCostQueryHandler(IRetailCostRepository retailCostRepository, IMapper mapper)
        {
            _retailCostRepository = retailCostRepository;
            _mapper = mapper;
        }

        public async Task<GetListResponse<GetListRetailCostListItemDto>> Handle(GetListRetailCostQuery request, CancellationToken cancellationToken)
        {
            IPaginate<RetailCost> retailCosts = await _retailCostRepository.GetListAsync(
                index: request.PageRequest.PageIndex,
                size: request.PageRequest.PageSize, 
                cancellationToken: cancellationToken
            );

            GetListResponse<GetListRetailCostListItemDto> response = _mapper.Map<GetListResponse<GetListRetailCostListItemDto>>(retailCosts);
            return response;
        }
    }
}