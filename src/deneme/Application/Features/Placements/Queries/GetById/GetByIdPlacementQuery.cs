using Application.Features.Placements.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.Placements.Queries.GetById;

public class GetByIdPlacementQuery : IRequest<GetByIdPlacementResponse>
{
    public Guid Id { get; set; }

    public class GetByIdPlacementQueryHandler : IRequestHandler<GetByIdPlacementQuery, GetByIdPlacementResponse>
    {
        private readonly IMapper _mapper;
        private readonly IPlacementRepository _placementRepository;
        private readonly PlacementBusinessRules _placementBusinessRules;

        public GetByIdPlacementQueryHandler(IMapper mapper, IPlacementRepository placementRepository, PlacementBusinessRules placementBusinessRules)
        {
            _mapper = mapper;
            _placementRepository = placementRepository;
            _placementBusinessRules = placementBusinessRules;
        }

        public async Task<GetByIdPlacementResponse> Handle(GetByIdPlacementQuery request, CancellationToken cancellationToken)
        {
            Placement? placement = await _placementRepository.GetAsync(predicate: p => p.Id == request.Id, cancellationToken: cancellationToken);
            await _placementBusinessRules.PlacementShouldExistWhenSelected(placement);

            GetByIdPlacementResponse response = _mapper.Map<GetByIdPlacementResponse>(placement);
            return response;
        }
    }
}