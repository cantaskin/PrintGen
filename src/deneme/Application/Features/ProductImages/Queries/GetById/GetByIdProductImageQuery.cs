using Application.Features.ProductImages.Constants;
using Application.Features.ProductImages.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using NArchitecture.Core.Application.Pipelines.Authorization;
using MediatR;
using static Application.Features.ProductImages.Constants.ProductImagesOperationClaims;

namespace Application.Features.ProductImages.Queries.GetById;

public class GetByIdProductImageQuery : IRequest<GetByIdProductImageResponse>, ISecuredRequest
{
    public Guid Id { get; set; }

    public string[] Roles => [Admin, Read];

    public class GetByIdProductImageQueryHandler : IRequestHandler<GetByIdProductImageQuery, GetByIdProductImageResponse>
    {
        private readonly IMapper _mapper;
        private readonly IProductImageRepository _productImageRepository;
        private readonly ProductImageBusinessRules _productImageBusinessRules;

        public GetByIdProductImageQueryHandler(IMapper mapper, IProductImageRepository productImageRepository, ProductImageBusinessRules productImageBusinessRules)
        {
            _mapper = mapper;
            _productImageRepository = productImageRepository;
            _productImageBusinessRules = productImageBusinessRules;
        }

        public async Task<GetByIdProductImageResponse> Handle(GetByIdProductImageQuery request, CancellationToken cancellationToken)
        {
            ProductImage? productImage = await _productImageRepository.GetAsync(predicate: pi => pi.Id == request.Id, cancellationToken: cancellationToken);
            await _productImageBusinessRules.ProductImageShouldExistWhenSelected(productImage);

            GetByIdProductImageResponse response = _mapper.Map<GetByIdProductImageResponse>(productImage);
            return response;
        }
    }
}