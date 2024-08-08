using Application.Features.CustomizedProducts.Constants;
using Application.Features.CustomizedProducts.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using NArchitecture.Core.Application.Pipelines.Authorization;
using MediatR;
using static Application.Features.CustomizedProducts.Constants.CustomizedProductsOperationClaims;

namespace Application.Features.CustomizedProducts.Queries.GetById;

public class GetByIdCustomizedProductQuery : IRequest<GetByIdCustomizedProductResponse>, ISecuredRequest
{
    public Guid Id { get; set; }

    public string[] Roles => [Admin, Read];

    public class GetByIdCustomizedProductQueryHandler : IRequestHandler<GetByIdCustomizedProductQuery, GetByIdCustomizedProductResponse>
    {
        private readonly IMapper _mapper;
        private readonly ICustomizedProductRepository _customizedProductRepository;
        private readonly CustomizedProductBusinessRules _customizedProductBusinessRules;

        public GetByIdCustomizedProductQueryHandler(IMapper mapper, ICustomizedProductRepository customizedProductRepository, CustomizedProductBusinessRules customizedProductBusinessRules)
        {
            _mapper = mapper;
            _customizedProductRepository = customizedProductRepository;
            _customizedProductBusinessRules = customizedProductBusinessRules;
        }

        public async Task<GetByIdCustomizedProductResponse> Handle(GetByIdCustomizedProductQuery request, CancellationToken cancellationToken)
        {
            CustomizedProduct? customizedProduct = await _customizedProductRepository.GetAsync(predicate: cp => cp.Id == request.Id, cancellationToken: cancellationToken);
            await _customizedProductBusinessRules.CustomizedProductShouldExistWhenSelected(customizedProduct);

            GetByIdCustomizedProductResponse response = _mapper.Map<GetByIdCustomizedProductResponse>(customizedProduct);
            return response;
        }
    }
}