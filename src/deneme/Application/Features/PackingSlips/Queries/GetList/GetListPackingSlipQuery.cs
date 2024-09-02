using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using NArchitecture.Core.Application.Requests;
using NArchitecture.Core.Application.Responses;
using NArchitecture.Core.Persistence.Paging;
using MediatR;

namespace Application.Features.PackingSlips.Queries.GetList;

public class GetListPackingSlipQuery : IRequest<GetListResponse<GetListPackingSlipListItemDto>>
{
    public PageRequest PageRequest { get; set; }

    public class GetListPackingSlipQueryHandler : IRequestHandler<GetListPackingSlipQuery, GetListResponse<GetListPackingSlipListItemDto>>
    {
        private readonly IPackingSlipRepository _packingSlipRepository;
        private readonly IMapper _mapper;

        public GetListPackingSlipQueryHandler(IPackingSlipRepository packingSlipRepository, IMapper mapper)
        {
            _packingSlipRepository = packingSlipRepository;
            _mapper = mapper;
        }

        public async Task<GetListResponse<GetListPackingSlipListItemDto>> Handle(GetListPackingSlipQuery request, CancellationToken cancellationToken)
        {
            IPaginate<PackingSlip> packingSlips = await _packingSlipRepository.GetListAsync(
                index: request.PageRequest.PageIndex,
                size: request.PageRequest.PageSize, 
                cancellationToken: cancellationToken
            );

            GetListResponse<GetListPackingSlipListItemDto> response = _mapper.Map<GetListResponse<GetListPackingSlipListItemDto>>(packingSlips);
            return response;
        }
    }
}