using Application.Features.Customizations.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.Customizations.Commands.Create;

public class CreateCustomizationCommand : IRequest<CreatedCustomizationResponse>
{
    public Guid? GiftId { get; set; }
    public required Guid PackingSlipId { get; set; }

    public class CreateCustomizationCommandHandler : IRequestHandler<CreateCustomizationCommand, CreatedCustomizationResponse>
    {
        private readonly IMapper _mapper;
        private readonly ICustomizationRepository _customizationRepository;
        private readonly CustomizationBusinessRules _customizationBusinessRules;

        public CreateCustomizationCommandHandler(IMapper mapper, ICustomizationRepository customizationRepository,
                                         CustomizationBusinessRules customizationBusinessRules)
        {
            _mapper = mapper;
            _customizationRepository = customizationRepository;
            _customizationBusinessRules = customizationBusinessRules;
        }

        public async Task<CreatedCustomizationResponse> Handle(CreateCustomizationCommand request, CancellationToken cancellationToken)
        {
            Customization customization = _mapper.Map<Customization>(request);

            await _customizationRepository.AddAsync(customization);

            CreatedCustomizationResponse response = _mapper.Map<CreatedCustomizationResponse>(customization);
            return response;
        }
    }
}