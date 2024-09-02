using Application.Features.Layers.Constants;
using Application.Features.Layers.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.Layers.Commands.Delete;

public class DeleteLayerCommand : IRequest<DeletedLayerResponse>
{
    public Guid Id { get; set; }

    public class DeleteLayerCommandHandler : IRequestHandler<DeleteLayerCommand, DeletedLayerResponse>
    {
        private readonly IMapper _mapper;
        private readonly ILayerRepository _layerRepository;
        private readonly LayerBusinessRules _layerBusinessRules;

        public DeleteLayerCommandHandler(IMapper mapper, ILayerRepository layerRepository,
                                         LayerBusinessRules layerBusinessRules)
        {
            _mapper = mapper;
            _layerRepository = layerRepository;
            _layerBusinessRules = layerBusinessRules;
        }

        public async Task<DeletedLayerResponse> Handle(DeleteLayerCommand request, CancellationToken cancellationToken)
        {
            Layer? layer = await _layerRepository.GetAsync(predicate: l => l.Id == request.Id, cancellationToken: cancellationToken);
            await _layerBusinessRules.LayerShouldExistWhenSelected(layer);

            await _layerRepository.DeleteAsync(layer!);

            DeletedLayerResponse response = _mapper.Map<DeletedLayerResponse>(layer);
            return response;
        }
    }
}