using Application.Features.TemplateProducts.Queries.GetList;
using Application.Services.Repositories;
using Application.Services.TemplateProducts;
using AutoMapper;
using MediatR;
using NArchitecture.Core.Application.Requests;
using NArchitecture.Core.Application.Responses;
using NArchitecture.Core.Persistence.Dynamic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.TemplateProducts.Queries.GetDynamicList;
public class GetDynamicListTemplateProductQuery : IRequest<GetListResponse<GetDynamicListTemplateProductListItemDto>>
{
    public PageRequest PageRequest { get; set; }

    public DynamicQuery DynamicQuery { get; set; }
    public class GetDynamicListTemplateProductQueryHandler : IRequestHandler<GetDynamicListTemplateProductQuery, GetListResponse<GetDynamicListTemplateProductListItemDto>>
    {
        private readonly ITemplateProductRepository _templateProductRepository;
        private readonly IMapper _mapper;
        public GetDynamicListTemplateProductQueryHandler(ITemplateProductRepository templateProductRepository, IMapper mapper)
        {
            _templateProductRepository = templateProductRepository;
            _mapper = mapper;
        }

        public async Task<GetListResponse<GetDynamicListTemplateProductListItemDto>> Handle(GetDynamicListTemplateProductQuery request, CancellationToken cancellationToken)
        {
            var dynamic = await _templateProductRepository.GetListByDynamicAsync(request.DynamicQuery,
                index: request.PageRequest.PageIndex, size: request.PageRequest.PageSize);


            GetListResponse<GetDynamicListTemplateProductListItemDto> response =
                _mapper.Map<GetListResponse<GetDynamicListTemplateProductListItemDto>>(dynamic);

            return response;
        }
    }
}
