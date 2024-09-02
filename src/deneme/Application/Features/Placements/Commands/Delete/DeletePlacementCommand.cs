using Application.Features.Placements.Constants;
using Application.Features.Placements.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.Placements.Commands.Delete;

public class DeletePlacementCommand : IRequest<DeletedPlacementResponse>
{
    public Guid Id { get; set; }

    public class DeletePlacementCommandHandler : IRequestHandler<DeletePlacementCommand, DeletedPlacementResponse>
    {
        private readonly IMapper _mapper;
        private readonly IPlacementRepository _placementRepository;
        private readonly PlacementBusinessRules _placementBusinessRules;

        public DeletePlacementCommandHandler(IMapper mapper, IPlacementRepository placementRepository,
                                         PlacementBusinessRules placementBusinessRules)
        {
            _mapper = mapper;
            _placementRepository = placementRepository;
            _placementBusinessRules = placementBusinessRules;
        }

        public async Task<DeletedPlacementResponse> Handle(DeletePlacementCommand request, CancellationToken cancellationToken)
        {
            Placement? placement = await _placementRepository.GetAsync(predicate: p => p.Id == request.Id, cancellationToken: cancellationToken);
            await _placementBusinessRules.PlacementShouldExistWhenSelected(placement);

            await _placementRepository.DeleteAsync(placement!);

            DeletedPlacementResponse response = _mapper.Map<DeletedPlacementResponse>(placement);
            return response;
        }
    }
}