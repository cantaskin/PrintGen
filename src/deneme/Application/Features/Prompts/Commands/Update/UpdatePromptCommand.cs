using Application.Features.Prompts.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.Prompts.Commands.Update;

public class UpdatePromptCommand : IRequest<UpdatedPromptResponse>
{
    public Guid Id { get; set; }
    public required string PromptString { get; set; }
    public CustomizedImage? CustomizedImage { get; set; }

    public class UpdatePromptCommandHandler : IRequestHandler<UpdatePromptCommand, UpdatedPromptResponse>
    {
        private readonly IMapper _mapper;
        private readonly IPromptRepository _promptRepository;
        private readonly PromptBusinessRules _promptBusinessRules;

        public UpdatePromptCommandHandler(IMapper mapper, IPromptRepository promptRepository,
                                         PromptBusinessRules promptBusinessRules)
        {
            _mapper = mapper;
            _promptRepository = promptRepository;
            _promptBusinessRules = promptBusinessRules;
        }

        public async Task<UpdatedPromptResponse> Handle(UpdatePromptCommand request, CancellationToken cancellationToken)
        {
            Prompt? prompt = await _promptRepository.GetAsync(predicate: p => p.Id == request.Id, cancellationToken: cancellationToken);
            await _promptBusinessRules.PromptShouldExistWhenSelected(prompt);
            prompt = _mapper.Map(request, prompt);

            await _promptRepository.UpdateAsync(prompt!);

            UpdatedPromptResponse response = _mapper.Map<UpdatedPromptResponse>(prompt);
            return response;
        }
    }
}