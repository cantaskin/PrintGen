using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using NArchitecture.Core.Application.Requests;
using NArchitecture.Core.Application.Responses;
using NArchitecture.Core.Persistence.Paging;
using MediatR;

namespace Application.Features.TemplateProducts.Queries.GetList;

public class GetListTemplateProductQuery : IRequest<GetListResponse<GetListTemplateProductListItemDto>>
{
    public PageRequest PageRequest { get; set; }

    public class GetListTemplateProductQueryHandler : IRequestHandler<GetListTemplateProductQuery, GetListResponse<GetListTemplateProductListItemDto>>
    {
        private readonly ITemplateProductRepository _templateProductRepository;
        private readonly IMapper _mapper;

        public GetListTemplateProductQueryHandler(ITemplateProductRepository templateProductRepository, IMapper mapper)
        {
            _templateProductRepository = templateProductRepository;
            _mapper = mapper;
        }

        public async Task<GetListResponse<GetListTemplateProductListItemDto>> Handle(GetListTemplateProductQuery request, CancellationToken cancellationToken)
        {
            IPaginate<TemplateProduct> templateProducts = await _templateProductRepository.GetListAsync(
                index: request.PageRequest.PageIndex,
                size: request.PageRequest.PageSize, 
                cancellationToken: cancellationToken
            );

            GetListResponse<GetListTemplateProductListItemDto> response = _mapper.Map<GetListResponse<GetListTemplateProductListItemDto>>(templateProducts);
            return response;
        }
    }
}