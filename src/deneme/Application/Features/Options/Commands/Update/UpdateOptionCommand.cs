using Application.Features.Options.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.Options.Commands.Update;

public class UpdateOptionCommand : IRequest<UpdatedOptionResponse>
{
    public Guid Id { get; set; }
    public required string Name { get; set; }
    public required string Value { get; set; }

    public class UpdateOptionCommandHandler : IRequestHandler<UpdateOptionCommand, UpdatedOptionResponse>
    {
        private readonly IMapper _mapper;
        private readonly IOptionRepository _optionRepository;
        private readonly OptionBusinessRules _optionBusinessRules;

        public UpdateOptionCommandHandler(IMapper mapper, IOptionRepository optionRepository,
                                         OptionBusinessRules optionBusinessRules)
        {
            _mapper = mapper;
            _optionRepository = optionRepository;
            _optionBusinessRules = optionBusinessRules;
        }

        public async Task<UpdatedOptionResponse> Handle(UpdateOptionCommand request, CancellationToken cancellationToken)
        {
            Option? option = await _optionRepository.GetAsync(predicate: o => o.Id == request.Id, cancellationToken: cancellationToken);
            await _optionBusinessRules.OptionShouldExistWhenSelected(option);
            option = _mapper.Map(request, option);

            await _optionRepository.UpdateAsync(option!);

            UpdatedOptionResponse response = _mapper.Map<UpdatedOptionResponse>(option);
            return response;
        }
    }
}