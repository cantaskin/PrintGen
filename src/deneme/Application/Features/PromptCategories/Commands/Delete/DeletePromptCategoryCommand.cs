using Application.Features.PromptCategories.Constants;
using Application.Features.PromptCategories.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;
using NArchitecture.Core.Application.Pipelines.Authorization;

namespace Application.Features.PromptCategories.Commands.Delete;

public class DeletePromptCategoryCommand : IRequest<DeletedPromptCategoryResponse>, ISecuredRequest
{
    public Guid Id { get; set; }

    public string[] Roles => [];

    public class DeletePromptCategoryCommandHandler : IRequestHandler<DeletePromptCategoryCommand, DeletedPromptCategoryResponse>
    {
        private readonly IMapper _mapper;
        private readonly IPromptCategoryRepository _promptCategoryRepository;
        private readonly PromptCategoryBusinessRules _promptCategoryBusinessRules;

        public DeletePromptCategoryCommandHandler(IMapper mapper, IPromptCategoryRepository promptCategoryRepository,
                                         PromptCategoryBusinessRules promptCategoryBusinessRules)
        {
            _mapper = mapper;
            _promptCategoryRepository = promptCategoryRepository;
            _promptCategoryBusinessRules = promptCategoryBusinessRules;
        }

        public async Task<DeletedPromptCategoryResponse> Handle(DeletePromptCategoryCommand request, CancellationToken cancellationToken)
        {
            PromptCategory? promptCategory = await _promptCategoryRepository.GetAsync(predicate: pc => pc.Id == request.Id, cancellationToken: cancellationToken);
            await _promptCategoryBusinessRules.PromptCategoryShouldExistWhenSelected(promptCategory);

            await _promptCategoryRepository.DeleteAsync(promptCategory!);

            DeletedPromptCategoryResponse response = _mapper.Map<DeletedPromptCategoryResponse>(promptCategory);
            return response;
        }
    }


}