using Application.Features.CustomizedProducts.Constants;
using Application.Features.CustomizedProducts.Constants;
using Application.Features.CustomizedProducts.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using NArchitecture.Core.Application.Pipelines.Authorization;
using NArchitecture.Core.Application.Pipelines.Caching;
using NArchitecture.Core.Application.Pipelines.Logging;
using NArchitecture.Core.Application.Pipelines.Transaction;
using MediatR;
using static Application.Features.CustomizedProducts.Constants.CustomizedProductsOperationClaims;

namespace Application.Features.CustomizedProducts.Commands.Delete;

public class DeleteCustomizedProductCommand : IRequest<DeletedCustomizedProductResponse>, ISecuredRequest, ICacheRemoverRequest, ILoggableRequest, ITransactionalRequest
{
    public Guid Id { get; set; }

    public string[] Roles => [Admin, Write, CustomizedProductsOperationClaims.Delete];

    public bool BypassCache { get; }
    public string? CacheKey { get; }
    public string[]? CacheGroupKey => ["GetCustomizedProducts"];

    public class DeleteCustomizedProductCommandHandler : IRequestHandler<DeleteCustomizedProductCommand, DeletedCustomizedProductResponse>
    {
        private readonly IMapper _mapper;
        private readonly ICustomizedProductRepository _customizedProductRepository;
        private readonly CustomizedProductBusinessRules _customizedProductBusinessRules;

        public DeleteCustomizedProductCommandHandler(IMapper mapper, ICustomizedProductRepository customizedProductRepository,
                                         CustomizedProductBusinessRules customizedProductBusinessRules)
        {
            _mapper = mapper;
            _customizedProductRepository = customizedProductRepository;
            _customizedProductBusinessRules = customizedProductBusinessRules;
        }

        public async Task<DeletedCustomizedProductResponse> Handle(DeleteCustomizedProductCommand request, CancellationToken cancellationToken)
        {
            CustomizedProduct? customizedProduct = await _customizedProductRepository.GetAsync(predicate: cp => cp.Id == request.Id, cancellationToken: cancellationToken);
            await _customizedProductBusinessRules.CustomizedProductShouldExistWhenSelected(customizedProduct);

            await _customizedProductRepository.DeleteAsync(customizedProduct!);

            DeletedCustomizedProductResponse response = _mapper.Map<DeletedCustomizedProductResponse>(customizedProduct);
            return response;
        }
    }
}