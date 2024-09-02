using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using NArchitecture.Core.Application.Requests;
using NArchitecture.Core.Application.Responses;
using NArchitecture.Core.Persistence.Paging;
using MediatR;

namespace Application.Features.Layers.Queries.GetList;

public class GetListLayerQuery : IRequest<GetListResponse<GetListLayerListItemDto>>
{
    public PageRequest PageRequest { get; set; }

    public class GetListLayerQueryHandler : IRequestHandler<GetListLayerQuery, GetListResponse<GetListLayerListItemDto>>
    {
        private readonly ILayerRepository _layerRepository;
        private readonly IMapper _mapper;

        public GetListLayerQueryHandler(ILayerRepository layerRepository, IMapper mapper)
        {
            _layerRepository = layerRepository;
            _mapper = mapper;
        }

        public async Task<GetListResponse<GetListLayerListItemDto>> Handle(GetListLayerQuery request, CancellationToken cancellationToken)
        {
            IPaginate<Layer> layers = await _layerRepository.GetListAsync(
                index: request.PageRequest.PageIndex,
                size: request.PageRequest.PageSize, 
                cancellationToken: cancellationToken
            );

            GetListResponse<GetListLayerListItemDto> response = _mapper.Map<GetListResponse<GetListLayerListItemDto>>(layers);
            return response;
        }
    }
}