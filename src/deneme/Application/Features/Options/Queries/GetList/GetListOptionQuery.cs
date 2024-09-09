using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using NArchitecture.Core.Application.Requests;
using NArchitecture.Core.Application.Responses;
using NArchitecture.Core.Persistence.Paging;
using MediatR;

namespace Application.Features.Options.Queries.GetList;

public class GetListOptionQuery : IRequest<GetListResponse<GetListOptionListItemDto>>
{
    public PageRequest PageRequest { get; set; }

    public class GetListOptionQueryHandler : IRequestHandler<GetListOptionQuery, GetListResponse<GetListOptionListItemDto>>
    {
        private readonly IOptionRepository _optionRepository;
        private readonly IMapper _mapper;

        public GetListOptionQueryHandler(IOptionRepository optionRepository, IMapper mapper)
        {
            _optionRepository = optionRepository;
            _mapper = mapper;
        }

        public async Task<GetListResponse<GetListOptionListItemDto>> Handle(GetListOptionQuery request, CancellationToken cancellationToken)
        {
            IPaginate<Option> options = await _optionRepository.GetListAsync(
                index: request.PageRequest.PageIndex,
                size: request.PageRequest.PageSize, 
                cancellationToken: cancellationToken
            );

            GetListResponse<GetListOptionListItemDto> response = _mapper.Map<GetListResponse<GetListOptionListItemDto>>(options);
            return response;
        }
    }
}