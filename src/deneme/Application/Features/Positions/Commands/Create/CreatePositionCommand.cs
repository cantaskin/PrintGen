using Application.Features.Positions.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.Positions.Commands.Create;

public class CreatePositionCommand : IRequest<CreatedPositionResponse>
{
    public required float Width { get; set; }
    public required float Height { get; set; }
    public required float Top { get; set; }
    public required float Left { get; set; }

    public class CreatePositionCommandHandler : IRequestHandler<CreatePositionCommand, CreatedPositionResponse>
    {
        private readonly IMapper _mapper;
        private readonly IPositionRepository _positionRepository;
        private readonly PositionBusinessRules _positionBusinessRules;

        public CreatePositionCommandHandler(IMapper mapper, IPositionRepository positionRepository,
                                         PositionBusinessRules positionBusinessRules)
        {
            _mapper = mapper;
            _positionRepository = positionRepository;
            _positionBusinessRules = positionBusinessRules;
        }

        public async Task<CreatedPositionResponse> Handle(CreatePositionCommand request, CancellationToken cancellationToken)
        {
            Position position = _mapper.Map<Position>(request);

            await _positionRepository.AddAsync(position);

            CreatedPositionResponse response = _mapper.Map<CreatedPositionResponse>(position);
            return response;
        }
    }
}