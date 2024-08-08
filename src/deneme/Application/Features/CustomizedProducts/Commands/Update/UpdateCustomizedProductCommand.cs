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

namespace Application.Features.CustomizedProducts.Commands.Update;

public class UpdateCustomizedProductCommand : IRequest<UpdatedCustomizedProductResponse>, ISecuredRequest, ICacheRemoverRequest, ILoggableRequest, ITransactionalRequest
{
    public Guid Id { get; set; }
    public required Guid ProductId { get; set; }
    public required Guid OwnerUserId { get; set; }
    public required bool IsPublished { get; set; }

    public string[] Roles => [Admin, Write, CustomizedProductsOperationClaims.Update];

    public bool BypassCache { get; }
    public string? CacheKey { get; }
    public string[]? CacheGroupKey => ["GetCustomizedProducts"];

    public class UpdateCustomizedProductCommandHandler : IRequestHandler<UpdateCustomizedProductCommand, UpdatedCustomizedProductResponse>
    {
        private readonly IMapper _mapper;
        private readonly ICustomizedProductRepository _customizedProductRepository;
        private readonly CustomizedProductBusinessRules _customizedProductBusinessRules;

        public UpdateCustomizedProductCommandHandler(IMapper mapper, ICustomizedProductRepository customizedProductRepository,
                                         CustomizedProductBusinessRules customizedProductBusinessRules)
        {
            _mapper = mapper;
            _customizedProductRepository = customizedProductRepository;
            _customizedProductBusinessRules = customizedProductBusinessRules;
        }

        public async Task<UpdatedCustomizedProductResponse> Handle(UpdateCustomizedProductCommand request, CancellationToken cancellationToken)
        {
            CustomizedProduct? customizedProduct = await _customizedProductRepository.GetAsync(predicate: cp => cp.Id == request.Id, cancellationToken: cancellationToken);
            await _customizedProductBusinessRules.CustomizedProductShouldExistWhenSelected(customizedProduct);
            customizedProduct = _mapper.Map(request, customizedProduct);

            await _customizedProductRepository.UpdateAsync(customizedProduct!);

            UpdatedCustomizedProductResponse response = _mapper.Map<UpdatedCustomizedProductResponse>(customizedProduct);
            return response;
        }
    }
}