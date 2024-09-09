using Application.Features.Prompts.Constants;
using Application.Features.Prompts.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;
using NArchitecture.Core.Application.Pipelines.Authorization;

namespace Application.Features.Prompts.Commands.Delete;

public class DeletePromptCommand : IRequest<DeletedPromptResponse>, ISecuredRequest
{
    public Guid Id { get; set; }

    public string[] Roles => [];
    public class DeletePromptCommandHandler : IRequestHandler<DeletePromptCommand, DeletedPromptResponse>
    {
        private readonly IMapper _mapper;
        private readonly IPromptRepository _promptRepository;
        private readonly PromptBusinessRules _promptBusinessRules;

        public DeletePromptCommandHandler(IMapper mapper, IPromptRepository promptRepository,
                                         PromptBusinessRules promptBusinessRules)
        {
            _mapper = mapper;
            _promptRepository = promptRepository;
            _promptBusinessRules = promptBusinessRules;
        }

        public async Task<DeletedPromptResponse> Handle(DeletePromptCommand request, CancellationToken cancellationToken)
        {
            Prompt? prompt = await _promptRepository.GetAsync(predicate: p => p.Id == request.Id, cancellationToken: cancellationToken);
            await _promptBusinessRules.PromptShouldExistWhenSelected(prompt);

            await _promptRepository.DeleteAsync(prompt!);

            DeletedPromptResponse response = _mapper.Map<DeletedPromptResponse>(prompt);
            return response;
        }
    }

    
}