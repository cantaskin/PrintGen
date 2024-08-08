using Application.Features.ProductImages.Constants;
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

namespace Application.Features.ProductImages.Commands.Delete;

public class DeleteProductImageCommand : IRequest<DeletedProductImageResponse>, ISecuredRequest, ICacheRemoverRequest, ILoggableRequest, ITransactionalRequest
{
    public Guid Id { get; set; }

    public string[] Roles => [Admin, Write, ProductImagesOperationClaims.Delete];

    public bool BypassCache { get; }
    public string? CacheKey { get; }
    public string[]? CacheGroupKey => ["GetProductImages"];

    public class DeleteProductImageCommandHandler : IRequestHandler<DeleteProductImageCommand, DeletedProductImageResponse>
    {
        private readonly IMapper _mapper;
        private readonly IProductImageRepository _productImageRepository;
        private readonly ProductImageBusinessRules _productImageBusinessRules;

        public DeleteProductImageCommandHandler(IMapper mapper, IProductImageRepository productImageRepository,
                                         ProductImageBusinessRules productImageBusinessRules)
        {
            _mapper = mapper;
            _productImageRepository = productImageRepository;
            _productImageBusinessRules = productImageBusinessRules;
        }

        public async Task<DeletedProductImageResponse> Handle(DeleteProductImageCommand request, CancellationToken cancellationToken)
        {
            ProductImage? productImage = await _productImageRepository.GetAsync(predicate: pi => pi.Id == request.Id, cancellationToken: cancellationToken);
            await _productImageBusinessRules.ProductImageShouldExistWhenSelected(productImage);

            await _productImageRepository.DeleteAsync(productImage!);

            DeletedProductImageResponse response = _mapper.Map<DeletedProductImageResponse>(productImage);
            return response;
        }
    }
}