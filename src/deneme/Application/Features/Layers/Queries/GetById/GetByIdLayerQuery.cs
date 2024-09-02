using Application.Features.Layers.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.Layers.Queries.GetById;

public class GetByIdLayerQuery : IRequest<GetByIdLayerResponse>
{
    public Guid Id { get; set; }

    public class GetByIdLayerQueryHandler : IRequestHandler<GetByIdLayerQuery, GetByIdLayerResponse>
    {
        private readonly IMapper _mapper;
        private readonly ILayerRepository _layerRepository;
        private readonly LayerBusinessRules _layerBusinessRules;

        public GetByIdLayerQueryHandler(IMapper mapper, ILayerRepository layerRepository, LayerBusinessRules layerBusinessRules)
        {
            _mapper = mapper;
            _layerRepository = layerRepository;
            _layerBusinessRules = layerBusinessRules;
        }

        public async Task<GetByIdLayerResponse> Handle(GetByIdLayerQuery request, CancellationToken cancellationToken)
        {
            Layer? layer = await _layerRepository.GetAsync(predicate: l => l.Id == request.Id, cancellationToken: cancellationToken);
            await _layerBusinessRules.LayerShouldExistWhenSelected(layer);

            GetByIdLayerResponse response = _mapper.Map<GetByIdLayerResponse>(layer);
            return response;
        }
    }
}