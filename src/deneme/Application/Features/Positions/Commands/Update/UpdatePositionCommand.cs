using Application.Features.Positions.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.Positions.Commands.Update;

public class UpdatePositionCommand : IRequest<UpdatedPositionResponse>
{
    public Guid Id { get; set; }
    public required float Width { get; set; }
    public required float Height { get; set; }
    public required float Top { get; set; }
    public required float Left { get; set; }

    public class UpdatePositionCommandHandler : IRequestHandler<UpdatePositionCommand, UpdatedPositionResponse>
    {
        private readonly IMapper _mapper;
        private readonly IPositionRepository _positionRepository;
        private readonly PositionBusinessRules _positionBusinessRules;

        public UpdatePositionCommandHandler(IMapper mapper, IPositionRepository positionRepository,
                                         PositionBusinessRules positionBusinessRules)
        {
            _mapper = mapper;
            _positionRepository = positionRepository;
            _positionBusinessRules = positionBusinessRules;
        }

        public async Task<UpdatedPositionResponse> Handle(UpdatePositionCommand request, CancellationToken cancellationToken)
        {
            Position? position = await _positionRepository.GetAsync(predicate: p => p.Id == request.Id, cancellationToken: cancellationToken);
            await _positionBusinessRules.PositionShouldExistWhenSelected(position);
            position = _mapper.Map(request, position);

            await _positionRepository.UpdateAsync(position!);

            UpdatedPositionResponse response = _mapper.Map<UpdatedPositionResponse>(position);
            return response;
        }
    }
}