using Application.Features.Customizations.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.Customizations.Queries.GetById;

public class GetByIdCustomizationQuery : IRequest<GetByIdCustomizationResponse>
{
    public Guid Id { get; set; }

    public class GetByIdCustomizationQueryHandler : IRequestHandler<GetByIdCustomizationQuery, GetByIdCustomizationResponse>
    {
        private readonly IMapper _mapper;
        private readonly ICustomizationRepository _customizationRepository;
        private readonly CustomizationBusinessRules _customizationBusinessRules;

        public GetByIdCustomizationQueryHandler(IMapper mapper, ICustomizationRepository customizationRepository, CustomizationBusinessRules customizationBusinessRules)
        {
            _mapper = mapper;
            _customizationRepository = customizationRepository;
            _customizationBusinessRules = customizationBusinessRules;
        }

        public async Task<GetByIdCustomizationResponse> Handle(GetByIdCustomizationQuery request, CancellationToken cancellationToken)
        {
            Customization? customization = await _customizationRepository.GetAsync(predicate: c => c.Id == request.Id, cancellationToken: cancellationToken);
            await _customizationBusinessRules.CustomizationShouldExistWhenSelected(customization);

            GetByIdCustomizationResponse response = _mapper.Map<GetByIdCustomizationResponse>(customization);
            return response;
        }
    }
}