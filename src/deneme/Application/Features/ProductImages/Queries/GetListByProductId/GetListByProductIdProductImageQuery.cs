using Application.Features.ProductImages.Queries.GetList;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using NArchitecture.Core.Application.Requests;
using NArchitecture.Core.Application.Responses;
using NArchitecture.Core.Persistence.Paging;

namespace Application.Features.ProductImages.Queries.GetListByProductId;
public class GetListByProductIdProductImageQuery : IRequest<GetListResponse<GetListProductImageListItemDto>>
{
    public Guid ProductId { get; set; }
    public PageRequest PageRequest { get; set; }

    public class GetListByProductIdProductImageHandler
        : IRequestHandler<GetListByProductIdProductImageQuery, GetListResponse<GetListProductImageListItemDto>>
    {
        private readonly IProductImageRepository _productImageRepository;
        private readonly IMapper _mapper;

        public GetListByProductIdProductImageHandler(IProductImageRepository productImageRepository, IMapper mapper)
        {
            _productImageRepository = productImageRepository;
            _mapper = mapper;
        }

        public async Task<GetListResponse<GetListProductImageListItemDto>> Handle(
            GetListByProductIdProductImageQuery request,
            CancellationToken cancellationToken
        )
        {
            IPaginate<ProductImage> productImage = await _productImageRepository.GetListAsync(
                predicate: c => c.ProductId == request.ProductId,
                include: c => c.Include(pi => pi.Product).Include(pi => pi.Product.Category).Include(pi => pi.Product.Color),
                index: request.PageRequest.PageIndex,
                size: request.PageRequest.PageSize
            );
            var mappedCarDamageListModel = _mapper.Map<GetListResponse<GetListProductImageListItemDto>>(productImage);
            return mappedCarDamageListModel;
        }
    }
}