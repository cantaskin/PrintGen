using Application.Features.Customizations.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.Customizations.Commands.Update;

public class UpdateCustomizationCommand : IRequest<UpdatedCustomizationResponse>
{
    public Guid Id { get; set; }
    public Guid? GiftId { get; set; }
    public Gift? Gift { get; set; }
    public required Guid PackingSlipId { get; set; }
    public required PackingSlip PackingSlip { get; set; }

    public class UpdateCustomizationCommandHandler : IRequestHandler<UpdateCustomizationCommand, UpdatedCustomizationResponse>
    {
        private readonly IMapper _mapper;
        private readonly ICustomizationRepository _customizationRepository;
        private readonly CustomizationBusinessRules _customizationBusinessRules;

        public UpdateCustomizationCommandHandler(IMapper mapper, ICustomizationRepository customizationRepository,
                                         CustomizationBusinessRules customizationBusinessRules)
        {
            _mapper = mapper;
            _customizationRepository = customizationRepository;
            _customizationBusinessRules = customizationBusinessRules;
        }

        public async Task<UpdatedCustomizationResponse> Handle(UpdateCustomizationCommand request, CancellationToken cancellationToken)
        {
            Customization? customization = await _customizationRepository.GetAsync(predicate: c => c.Id == request.Id, cancellationToken: cancellationToken);
            await _customizationBusinessRules.CustomizationShouldExistWhenSelected(customization);
            customization = _mapper.Map(request, customization);

            await _customizationRepository.UpdateAsync(customization!);

            UpdatedCustomizationResponse response = _mapper.Map<UpdatedCustomizationResponse>(customization);
            return response;
        }
    }
}