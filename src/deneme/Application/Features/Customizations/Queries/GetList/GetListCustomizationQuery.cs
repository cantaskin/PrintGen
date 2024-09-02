using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using NArchitecture.Core.Application.Requests;
using NArchitecture.Core.Application.Responses;
using NArchitecture.Core.Persistence.Paging;
using MediatR;

namespace Application.Features.Customizations.Queries.GetList;

public class GetListCustomizationQuery : IRequest<GetListResponse<GetListCustomizationListItemDto>>
{
    public PageRequest PageRequest { get; set; }

    public class GetListCustomizationQueryHandler : IRequestHandler<GetListCustomizationQuery, GetListResponse<GetListCustomizationListItemDto>>
    {
        private readonly ICustomizationRepository _customizationRepository;
        private readonly IMapper _mapper;

        public GetListCustomizationQueryHandler(ICustomizationRepository customizationRepository, IMapper mapper)
        {
            _customizationRepository = customizationRepository;
            _mapper = mapper;
        }

        public async Task<GetListResponse<GetListCustomizationListItemDto>> Handle(GetListCustomizationQuery request, CancellationToken cancellationToken)
        {
            IPaginate<Customization> customizations = await _customizationRepository.GetListAsync(
                index: request.PageRequest.PageIndex,
                size: request.PageRequest.PageSize, 
                cancellationToken: cancellationToken
            );

            GetListResponse<GetListCustomizationListItemDto> response = _mapper.Map<GetListResponse<GetListCustomizationListItemDto>>(customizations);
            return response;
        }
    }
}