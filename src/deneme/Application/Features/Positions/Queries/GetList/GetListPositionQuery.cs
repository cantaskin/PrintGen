using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using NArchitecture.Core.Application.Requests;
using NArchitecture.Core.Application.Responses;
using NArchitecture.Core.Persistence.Paging;
using MediatR;

namespace Application.Features.Positions.Queries.GetList;

public class GetListPositionQuery : IRequest<GetListResponse<GetListPositionListItemDto>>
{
    public PageRequest PageRequest { get; set; }

    public class GetListPositionQueryHandler : IRequestHandler<GetListPositionQuery, GetListResponse<GetListPositionListItemDto>>
    {
        private readonly IPositionRepository _positionRepository;
        private readonly IMapper _mapper;

        public GetListPositionQueryHandler(IPositionRepository positionRepository, IMapper mapper)
        {
            _positionRepository = positionRepository;
            _mapper = mapper;
        }

        public async Task<GetListResponse<GetListPositionListItemDto>> Handle(GetListPositionQuery request, CancellationToken cancellationToken)
        {
            IPaginate<Position> positions = await _positionRepository.GetListAsync(
                index: request.PageRequest.PageIndex,
                size: request.PageRequest.PageSize, 
                cancellationToken: cancellationToken
            );

            GetListResponse<GetListPositionListItemDto> response = _mapper.Map<GetListResponse<GetListPositionListItemDto>>(positions);
            return response;
        }
    }
}