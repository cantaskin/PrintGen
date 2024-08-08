using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using NArchitecture.Core.Application.Requests;
using NArchitecture.Core.Application.Responses;
using NArchitecture.Core.Persistence.Paging;
using MediatR;

namespace Application.Features.Prompts.Queries.GetList;

public class GetListPromptQuery : IRequest<GetListResponse<GetListPromptListItemDto>>
{
    public PageRequest PageRequest { get; set; }

    public class GetListPromptQueryHandler : IRequestHandler<GetListPromptQuery, GetListResponse<GetListPromptListItemDto>>
    {
        private readonly IPromptRepository _promptRepository;
        private readonly IMapper _mapper;

        public GetListPromptQueryHandler(IPromptRepository promptRepository, IMapper mapper)
        {
            _promptRepository = promptRepository;
            _mapper = mapper;
        }

        public async Task<GetListResponse<GetListPromptListItemDto>> Handle(GetListPromptQuery request, CancellationToken cancellationToken)
        {
            IPaginate<Prompt> prompts = await _promptRepository.GetListAsync(
                index: request.PageRequest.PageIndex,
                size: request.PageRequest.PageSize, 
                cancellationToken: cancellationToken
            );

            GetListResponse<GetListPromptListItemDto> response = _mapper.Map<GetListResponse<GetListPromptListItemDto>>(prompts);
            return response;
        }
    }
}