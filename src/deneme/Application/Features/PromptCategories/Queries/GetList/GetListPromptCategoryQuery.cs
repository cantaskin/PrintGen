using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using NArchitecture.Core.Application.Requests;
using NArchitecture.Core.Application.Responses;
using NArchitecture.Core.Persistence.Paging;
using MediatR;

namespace Application.Features.PromptCategories.Queries.GetList;

public class GetListPromptCategoryQuery : IRequest<GetListResponse<GetListPromptCategoryListItemDto>>
{
    public PageRequest PageRequest { get; set; }

    public class GetListPromptCategoryQueryHandler : IRequestHandler<GetListPromptCategoryQuery, GetListResponse<GetListPromptCategoryListItemDto>>
    {
        private readonly IPromptCategoryRepository _promptCategoryRepository;
        private readonly IMapper _mapper;

        public GetListPromptCategoryQueryHandler(IPromptCategoryRepository promptCategoryRepository, IMapper mapper)
        {
            _promptCategoryRepository = promptCategoryRepository;
            _mapper = mapper;
        }

        public async Task<GetListResponse<GetListPromptCategoryListItemDto>> Handle(GetListPromptCategoryQuery request, CancellationToken cancellationToken)
        {
            IPaginate<PromptCategory> promptCategories = await _promptCategoryRepository.GetListAsync(
                index: request.PageRequest.PageIndex,
                size: request.PageRequest.PageSize, 
                cancellationToken: cancellationToken
            );

            GetListResponse<GetListPromptCategoryListItemDto> response = _mapper.Map<GetListResponse<GetListPromptCategoryListItemDto>>(promptCategories);
            return response;
        }
    }
}