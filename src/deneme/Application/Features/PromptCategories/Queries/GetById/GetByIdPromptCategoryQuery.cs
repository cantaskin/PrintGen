using Application.Features.PromptCategories.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;
using NArchitecture.Core.Application.Pipelines.Authorization;

namespace Application.Features.PromptCategories.Queries.GetById;

public class GetByIdPromptCategoryQuery : IRequest<GetByIdPromptCategoryResponse>
{
    public Guid Id { get; set; }

    public class GetByIdPromptCategoryQueryHandler : IRequestHandler<GetByIdPromptCategoryQuery, GetByIdPromptCategoryResponse>
    {
        private readonly IMapper _mapper;
        private readonly IPromptCategoryRepository _promptCategoryRepository;
        private readonly PromptCategoryBusinessRules _promptCategoryBusinessRules;

        public GetByIdPromptCategoryQueryHandler(IMapper mapper, IPromptCategoryRepository promptCategoryRepository, PromptCategoryBusinessRules promptCategoryBusinessRules)
        {
            _mapper = mapper;
            _promptCategoryRepository = promptCategoryRepository;
            _promptCategoryBusinessRules = promptCategoryBusinessRules;
        }

        public async Task<GetByIdPromptCategoryResponse> Handle(GetByIdPromptCategoryQuery request, CancellationToken cancellationToken)
        {
            PromptCategory? promptCategory = await _promptCategoryRepository.GetAsync(predicate: pc => pc.Id == request.Id, cancellationToken: cancellationToken);
            await _promptCategoryBusinessRules.PromptCategoryShouldExistWhenSelected(promptCategory);

            GetByIdPromptCategoryResponse response = _mapper.Map<GetByIdPromptCategoryResponse>(promptCategory);
            return response;
        }
    }
}