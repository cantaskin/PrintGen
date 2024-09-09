using Application.Features.PromptCategories.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;
using NArchitecture.Core.Application.Pipelines.Authorization;

namespace Application.Features.PromptCategories.Commands.Create;

public class CreatePromptCategoryCommand : IRequest<CreatedPromptCategoryResponse>, ISecuredRequest
{
    public required string Name { get; set; }
    public required string Description { get; set; }

    public string[] Roles => [];


    public class CreatePromptCategoryCommandHandler : IRequestHandler<CreatePromptCategoryCommand, CreatedPromptCategoryResponse>
    {
        private readonly IMapper _mapper;
        private readonly IPromptCategoryRepository _promptCategoryRepository;
        private readonly PromptCategoryBusinessRules _promptCategoryBusinessRules;

        public CreatePromptCategoryCommandHandler(IMapper mapper, IPromptCategoryRepository promptCategoryRepository,
                                         PromptCategoryBusinessRules promptCategoryBusinessRules)
        {
            _mapper = mapper;
            _promptCategoryRepository = promptCategoryRepository;
            _promptCategoryBusinessRules = promptCategoryBusinessRules;
        }

        public async Task<CreatedPromptCategoryResponse> Handle(CreatePromptCategoryCommand request, CancellationToken cancellationToken)
        {
            PromptCategory promptCategory = _mapper.Map<PromptCategory>(request);

            await _promptCategoryRepository.AddAsync(promptCategory);

            CreatedPromptCategoryResponse response = _mapper.Map<CreatedPromptCategoryResponse>(promptCategory);
            return response;
        }
    }


}