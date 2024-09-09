using Application.Features.PromptCategories.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;
using NArchitecture.Core.Application.Pipelines.Authorization;

namespace Application.Features.PromptCategories.Commands.Update;

public class UpdatePromptCategoryCommand : IRequest<UpdatedPromptCategoryResponse>, ISecuredRequest
{
    public Guid Id { get; set; }
    public required string Name { get; set; }
    public required string Description { get; set; }

    public string[] Roles => [];

    public class UpdatePromptCategoryCommandHandler : IRequestHandler<UpdatePromptCategoryCommand, UpdatedPromptCategoryResponse>
    {
        private readonly IMapper _mapper;
        private readonly IPromptCategoryRepository _promptCategoryRepository;
        private readonly PromptCategoryBusinessRules _promptCategoryBusinessRules;

        public UpdatePromptCategoryCommandHandler(IMapper mapper, IPromptCategoryRepository promptCategoryRepository,
                                         PromptCategoryBusinessRules promptCategoryBusinessRules)
        {
            _mapper = mapper;
            _promptCategoryRepository = promptCategoryRepository;
            _promptCategoryBusinessRules = promptCategoryBusinessRules;
        }

        public async Task<UpdatedPromptCategoryResponse> Handle(UpdatePromptCategoryCommand request, CancellationToken cancellationToken)
        {
            PromptCategory? promptCategory = await _promptCategoryRepository.GetAsync(predicate: pc => pc.Id == request.Id, cancellationToken: cancellationToken);
            await _promptCategoryBusinessRules.PromptCategoryShouldExistWhenSelected(promptCategory);
            promptCategory = _mapper.Map(request, promptCategory);

            await _promptCategoryRepository.UpdateAsync(promptCategory!);

            UpdatedPromptCategoryResponse response = _mapper.Map<UpdatedPromptCategoryResponse>(promptCategory);
            return response;
        }
    }
}