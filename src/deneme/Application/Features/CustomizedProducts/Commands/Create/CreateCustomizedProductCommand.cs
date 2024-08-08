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

namespace Application.Features.CustomizedProducts.Commands.Create;

public class CreateCustomizedProductCommand : IRequest<CreatedCustomizedProductResponse>, ISecuredRequest, ICacheRemoverRequest, ILoggableRequest, ITransactionalRequest
{
    public required Guid ProductId { get; set; }
    public required Guid OwnerUserId { get; set; }
    public required bool IsPublished { get; set; }

    public string[] Roles => [Admin, Write, CustomizedProductsOperationClaims.Create];

    public bool BypassCache { get; }
    public string? CacheKey { get; }
    public string[]? CacheGroupKey => ["GetCustomizedProducts"];

    public class CreateCustomizedProductCommandHandler : IRequestHandler<CreateCustomizedProductCommand, CreatedCustomizedProductResponse>
    {
        private readonly IMapper _mapper;
        private readonly ICustomizedProductRepository _customizedProductRepository;
        private readonly CustomizedProductBusinessRules _customizedProductBusinessRules;

        public CreateCustomizedProductCommandHandler(IMapper mapper, ICustomizedProductRepository customizedProductRepository,
                                         CustomizedProductBusinessRules customizedProductBusinessRules)
        {
            _mapper = mapper;
            _customizedProductRepository = customizedProductRepository;
            _customizedProductBusinessRules = customizedProductBusinessRules;
        }

        public async Task<CreatedCustomizedProductResponse> Handle(CreateCustomizedProductCommand request, CancellationToken cancellationToken)
        {
            CustomizedProduct customizedProduct = _mapper.Map<CustomizedProduct>(request);

            await _customizedProductRepository.AddAsync(customizedProduct);

            CreatedCustomizedProductResponse response = _mapper.Map<CreatedCustomizedProductResponse>(customizedProduct);
            return response;
        }
    }
}