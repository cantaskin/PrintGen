using Application.Features.ProductImages.Constants;
using Application.Features.ProductImages.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using NArchitecture.Core.Application.Pipelines.Authorization;
using NArchitecture.Core.Application.Pipelines.Caching;
using NArchitecture.Core.Application.Pipelines.Logging;
using NArchitecture.Core.Application.Pipelines.Transaction;
using MediatR;
using static Application.Features.ProductImages.Constants.ProductImagesOperationClaims;

namespace Application.Features.ProductImages.Commands.Create;

public class CreateProductImageCommand : IRequest<CreatedProductImageResponse>, ISecuredRequest, ICacheRemoverRequest, ILoggableRequest, ITransactionalRequest
{
    public required string ImageUrl { get; set; }
    public required Guid ProductId { get; set; }

    public string[] Roles => [Admin, Write, ProductImagesOperationClaims.Create];

    public bool BypassCache { get; }
    public string? CacheKey { get; }
    public string[]? CacheGroupKey => ["GetProductImages"];

    public class CreateProductImageCommandHandler : IRequestHandler<CreateProductImageCommand, CreatedProductImageResponse>
    {
        private readonly IMapper _mapper;
        private readonly IProductImageRepository _productImageRepository;
        private readonly ProductImageBusinessRules _productImageBusinessRules;

        public CreateProductImageCommandHandler(IMapper mapper, IProductImageRepository productImageRepository,
                                         ProductImageBusinessRules productImageBusinessRules)
        {
            _mapper = mapper;
            _productImageRepository = productImageRepository;
            _productImageBusinessRules = productImageBusinessRules;
        }

        public async Task<CreatedProductImageResponse> Handle(CreateProductImageCommand request, CancellationToken cancellationToken)
        {
            ProductImage productImage = _mapper.Map<ProductImage>(request);

            await _productImageRepository.AddAsync(productImage);

            CreatedProductImageResponse response = _mapper.Map<CreatedProductImageResponse>(productImage);
            return response;
        }
    }
}