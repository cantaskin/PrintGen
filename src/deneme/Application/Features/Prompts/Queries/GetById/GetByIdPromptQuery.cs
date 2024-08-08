using Application.Features.Prompts.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.Prompts.Queries.GetById;

public class GetByIdPromptQuery : IRequest<GetByIdPromptResponse>
{
    public Guid Id { get; set; }

    public class GetByIdPromptQueryHandler : IRequestHandler<GetByIdPromptQuery, GetByIdPromptResponse>
    {
        private readonly IMapper _mapper;
        private readonly IPromptRepository _promptRepository;
        private readonly PromptBusinessRules _promptBusinessRules;

        public GetByIdPromptQueryHandler(IMapper mapper, IPromptRepository promptRepository, PromptBusinessRules promptBusinessRules)
        {
            _mapper = mapper;
            _promptRepository = promptRepository;
            _promptBusinessRules = promptBusinessRules;
        }

        public async Task<GetByIdPromptResponse> Handle(GetByIdPromptQuery request, CancellationToken cancellationToken)
        {
            Prompt? prompt = await _promptRepository.GetAsync(predicate: p => p.Id == request.Id, cancellationToken: cancellationToken);
            await _promptBusinessRules.PromptShouldExistWhenSelected(prompt);

            GetByIdPromptResponse response = _mapper.Map<GetByIdPromptResponse>(prompt);
            return response;
        }
    }
}