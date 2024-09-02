using Application.Features.Layers.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.Layers.Commands.Update;

public class UpdateLayerCommand : IRequest<UpdatedLayerResponse>
{
    public Guid Id { get; set; }
    public required string Type { get; set; }
    public required string Url { get; set; }
    public Guid? PositionId { get; set; }
    public Position? Position { get; set; }

    public class UpdateLayerCommandHandler : IRequestHandler<UpdateLayerCommand, UpdatedLayerResponse>
    {
        private readonly IMapper _mapper;
        private readonly ILayerRepository _layerRepository;
        private readonly LayerBusinessRules _layerBusinessRules;

        public UpdateLayerCommandHandler(IMapper mapper, ILayerRepository layerRepository,
                                         LayerBusinessRules layerBusinessRules)
        {
            _mapper = mapper;
            _layerRepository = layerRepository;
            _layerBusinessRules = layerBusinessRules;
        }

        public async Task<UpdatedLayerResponse> Handle(UpdateLayerCommand request, CancellationToken cancellationToken)
        {
            Layer? layer = await _layerRepository.GetAsync(predicate: l => l.Id == request.Id, cancellationToken: cancellationToken);
            await _layerBusinessRules.LayerShouldExistWhenSelected(layer);
            layer = _mapper.Map(request, layer);

            await _layerRepository.UpdateAsync(layer!);

            UpdatedLayerResponse response = _mapper.Map<UpdatedLayerResponse>(layer);
            return response;
        }
    }
}