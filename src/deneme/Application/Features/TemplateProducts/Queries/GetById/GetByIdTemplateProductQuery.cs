using Application.Features.TemplateProducts.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.TemplateProducts.Queries.GetById;

public class GetByIdTemplateProductQuery : IRequest<GetByIdTemplateProductResponse>
{
    public Guid Id { get; set; }

    public class GetByIdTemplateProductQueryHandler : IRequestHandler<GetByIdTemplateProductQuery, GetByIdTemplateProductResponse>
    {
        private readonly IMapper _mapper;
        private readonly ITemplateProductRepository _templateProductRepository;
        private readonly TemplateProductBusinessRules _templateProductBusinessRules;

        public GetByIdTemplateProductQueryHandler(IMapper mapper, ITemplateProductRepository templateProductRepository, TemplateProductBusinessRules templateProductBusinessRules)
        {
            _mapper = mapper;
            _templateProductRepository = templateProductRepository;
            _templateProductBusinessRules = templateProductBusinessRules;
        }

        public async Task<GetByIdTemplateProductResponse> Handle(GetByIdTemplateProductQuery request, CancellationToken cancellationToken)
        {
            TemplateProduct? templateProduct = await _templateProductRepository.GetAsync(predicate: tp => tp.Id == request.Id, cancellationToken: cancellationToken);
            await _templateProductBusinessRules.TemplateProductShouldExistWhenSelected(templateProduct);

            GetByIdTemplateProductResponse response = _mapper.Map<GetByIdTemplateProductResponse>(templateProduct);
            return response;
        }
    }
}