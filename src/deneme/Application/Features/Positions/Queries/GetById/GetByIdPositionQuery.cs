using Application.Features.Positions.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.Positions.Queries.GetById;

public class GetByIdPositionQuery : IRequest<GetByIdPositionResponse>
{
    public Guid Id { get; set; }

    public class GetByIdPositionQueryHandler : IRequestHandler<GetByIdPositionQuery, GetByIdPositionResponse>
    {
        private readonly IMapper _mapper;
        private readonly IPositionRepository _positionRepository;
        private readonly PositionBusinessRules _positionBusinessRules;

        public GetByIdPositionQueryHandler(IMapper mapper, IPositionRepository positionRepository, PositionBusinessRules positionBusinessRules)
        {
            _mapper = mapper;
            _positionRepository = positionRepository;
            _positionBusinessRules = positionBusinessRules;
        }

        public async Task<GetByIdPositionResponse> Handle(GetByIdPositionQuery request, CancellationToken cancellationToken)
        {
            Position? position = await _positionRepository.GetAsync(predicate: p => p.Id == request.Id, cancellationToken: cancellationToken);
            await _positionBusinessRules.PositionShouldExistWhenSelected(position);

            GetByIdPositionResponse response = _mapper.Map<GetByIdPositionResponse>(position);
            return response;
        }
    }
}