using Application.Features.Customizations.Constants;
using Application.Features.Customizations.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.Customizations.Commands.Delete;

public class DeleteCustomizationCommand : IRequest<DeletedCustomizationResponse>
{
    public Guid Id { get; set; }

    public class DeleteCustomizationCommandHandler : IRequestHandler<DeleteCustomizationCommand, DeletedCustomizationResponse>
    {
        private readonly IMapper _mapper;
        private readonly ICustomizationRepository _customizationRepository;
        private readonly CustomizationBusinessRules _customizationBusinessRules;

        public DeleteCustomizationCommandHandler(IMapper mapper, ICustomizationRepository customizationRepository,
                                         CustomizationBusinessRules customizationBusinessRules)
        {
            _mapper = mapper;
            _customizationRepository = customizationRepository;
            _customizationBusinessRules = customizationBusinessRules;
        }

        public async Task<DeletedCustomizationResponse> Handle(DeleteCustomizationCommand request, CancellationToken cancellationToken)
        {
            Customization? customization = await _customizationRepository.GetAsync(predicate: c => c.Id == request.Id, cancellationToken: cancellationToken);
            await _customizationBusinessRules.CustomizationShouldExistWhenSelected(customization);

            await _customizationRepository.DeleteAsync(customization!);

            DeletedCustomizationResponse response = _mapper.Map<DeletedCustomizationResponse>(customization);
            return response;
        }
    }
}