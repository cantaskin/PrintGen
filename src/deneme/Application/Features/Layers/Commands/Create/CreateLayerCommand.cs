using Application.Features.Layers.Rules;
using Application.Features.Positions.Commands.Create;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.Layers.Commands.Create;

public class CreateLayerCommand : IRequest<CreatedLayerResponse>
{
    public required string Type { get; set; } = "file";
    public required string Url { get; set; }
    public CreatePositionCommand? Position { get; set; }

    public class CreateLayerCommandHandler : IRequestHandler<CreateLayerCommand, CreatedLayerResponse>
    {
        private readonly IMapper _mapper;
        private readonly ILayerRepository _layerRepository;
        private readonly LayerBusinessRules _layerBusinessRules;

        public CreateLayerCommandHandler(IMapper mapper, ILayerRepository layerRepository,
                                         LayerBusinessRules layerBusinessRules)
        {
            _mapper = mapper;
            _layerRepository = layerRepository;
            _layerBusinessRules = layerBusinessRules;
        }

        public async Task<CreatedLayerResponse> Handle(CreateLayerCommand request, CancellationToken cancellationToken)
        {
            Layer layer = _mapper.Map<Layer>(request);

            await _layerRepository.AddAsync(layer);

            CreatedLayerResponse response = _mapper.Map<CreatedLayerResponse>(layer);
            return response;
        }
    }
}