using Application.Features.Placements.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.Placements.Commands.Update;

public class UpdatePlacementCommand : IRequest<UpdatedPlacementResponse>
{
    public Guid Id { get; set; }
    public required string PlacementName { get; set; }
    public required string Technique { get; set; }
    public Guid? PlacementOptionId { get; set; }

    public class UpdatePlacementCommandHandler : IRequestHandler<UpdatePlacementCommand, UpdatedPlacementResponse>
    {
        private readonly IMapper _mapper;
        private readonly IPlacementRepository _placementRepository;
        private readonly PlacementBusinessRules _placementBusinessRules;

        public UpdatePlacementCommandHandler(IMapper mapper, IPlacementRepository placementRepository,
                                         PlacementBusinessRules placementBusinessRules)
        {
            _mapper = mapper;
            _placementRepository = placementRepository;
            _placementBusinessRules = placementBusinessRules;
        }

        public async Task<UpdatedPlacementResponse> Handle(UpdatePlacementCommand request, CancellationToken cancellationToken)
        {
            Placement? placement = await _placementRepository.GetAsync(predicate: p => p.Id == request.Id, cancellationToken: cancellationToken);
            await _placementBusinessRules.PlacementShouldExistWhenSelected(placement);
            placement = _mapper.Map(request, placement);

            await _placementRepository.UpdateAsync(placement!);

            UpdatedPlacementResponse response = _mapper.Map<UpdatedPlacementResponse>(placement);
            return response;
        }
    }
}