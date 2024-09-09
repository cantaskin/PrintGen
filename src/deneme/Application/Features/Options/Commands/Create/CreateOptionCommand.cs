using Application.Features.Options.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.Options.Commands.Create;

public class CreateOptionCommand : IRequest<CreatedOptionResponse>
{
    public required string Name { get; set; }
    public required string Value { get; set; }

    public class CreateOptionCommandHandler : IRequestHandler<CreateOptionCommand, CreatedOptionResponse>
    {
        private readonly IMapper _mapper;
        private readonly IOptionRepository _optionRepository;
        private readonly OptionBusinessRules _optionBusinessRules;

        public CreateOptionCommandHandler(IMapper mapper, IOptionRepository optionRepository,
                                         OptionBusinessRules optionBusinessRules)
        {
            _mapper = mapper;
            _optionRepository = optionRepository;
            _optionBusinessRules = optionBusinessRules;
        }

        public async Task<CreatedOptionResponse> Handle(CreateOptionCommand request, CancellationToken cancellationToken)
        {
            Option option = _mapper.Map<Option>(request);

            await _optionRepository.AddAsync(option);

            CreatedOptionResponse response = _mapper.Map<CreatedOptionResponse>(option);
            return response;
        }
    }
}