using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using NArchitecture.Core.Application.Requests;
using NArchitecture.Core.Application.Responses;
using NArchitecture.Core.Persistence.Paging;
using MediatR;

namespace Application.Features.Placements.Queries.GetList;

public class GetListPlacementQuery : IRequest<GetListResponse<GetListPlacementListItemDto>>
{
    public PageRequest PageRequest { get; set; }

    public class GetListPlacementQueryHandler : IRequestHandler<GetListPlacementQuery, GetListResponse<GetListPlacementListItemDto>>
    {
        private readonly IPlacementRepository _placementRepository;
        private readonly IMapper _mapper;

        public GetListPlacementQueryHandler(IPlacementRepository placementRepository, IMapper mapper)
        {
            _placementRepository = placementRepository;
            _mapper = mapper;
        }

        public async Task<GetListResponse<GetListPlacementListItemDto>> Handle(GetListPlacementQuery request, CancellationToken cancellationToken)
        {
            IPaginate<Placement> placements = await _placementRepository.GetListAsync(
                index: request.PageRequest.PageIndex,
                size: request.PageRequest.PageSize, 
                cancellationToken: cancellationToken
            );

            GetListResponse<GetListPlacementListItemDto> response = _mapper.Map<GetListResponse<GetListPlacementListItemDto>>(placements);
            return response;
        }
    }
}