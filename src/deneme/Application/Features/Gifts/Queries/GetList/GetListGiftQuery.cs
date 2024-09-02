using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using NArchitecture.Core.Application.Requests;
using NArchitecture.Core.Application.Responses;
using NArchitecture.Core.Persistence.Paging;
using MediatR;

namespace Application.Features.Gifts.Queries.GetList;

public class GetListGiftQuery : IRequest<GetListResponse<GetListGiftListItemDto>>
{
    public PageRequest PageRequest { get; set; }

    public class GetListGiftQueryHandler : IRequestHandler<GetListGiftQuery, GetListResponse<GetListGiftListItemDto>>
    {
        private readonly IGiftRepository _giftRepository;
        private readonly IMapper _mapper;

        public GetListGiftQueryHandler(IGiftRepository giftRepository, IMapper mapper)
        {
            _giftRepository = giftRepository;
            _mapper = mapper;
        }

        public async Task<GetListResponse<GetListGiftListItemDto>> Handle(GetListGiftQuery request, CancellationToken cancellationToken)
        {
            IPaginate<Gift> gifts = await _giftRepository.GetListAsync(
                index: request.PageRequest.PageIndex,
                size: request.PageRequest.PageSize, 
                cancellationToken: cancellationToken
            );

            GetListResponse<GetListGiftListItemDto> response = _mapper.Map<GetListResponse<GetListGiftListItemDto>>(gifts);
            return response;
        }
    }
}