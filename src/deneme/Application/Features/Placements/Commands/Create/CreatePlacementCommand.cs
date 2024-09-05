using Application.Features.Layers.Commands.Create;
using Application.Features.Placements.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.Placements.Commands.Create;

public class CreatePlacementCommand : IRequest<CreatedPlacementResponse>
{
    public required string PlacementName { get; set; }
    public required string Technique { get; set; }

    public required List<CreateLayerCommand> Layers { get; set; }
  //  public Guid? PlacementOptionId { get; set; }

    public class CreatePlacementCommandHandler : IRequestHandler<CreatePlacementCommand, CreatedPlacementResponse>
    {
        private readonly IMapper _mapper;
        private readonly IPlacementRepository _placementRepository;
        private readonly PlacementBusinessRules _placementBusinessRules;

        public CreatePlacementCommandHandler(IMapper mapper, IPlacementRepository placementRepository,
                                         PlacementBusinessRules placementBusinessRules)
        {
            _mapper = mapper;
            _placementRepository = placementRepository;
            _placementBusinessRules = placementBusinessRules;
        }

        public async Task<CreatedPlacementResponse> Handle(CreatePlacementCommand request, CancellationToken cancellationToken)
        {
            Placement placement = _mapper.Map<Placement>(request);

            await _placementRepository.AddAsync(placement);

            CreatedPlacementResponse response = _mapper.Map<CreatedPlacementResponse>(placement);
            return response;
        }
    }
}