using Application.Features.PackingSlips.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.PackingSlips.Commands.Update;

public class UpdatePackingSlipCommand : IRequest<UpdatedPackingSlipResponse>
{
    public Guid Id { get; set; }
    public required string Email { get; set; }
    public required string Phone { get; set; }
    public required string Message { get; set; }
    public required string LogoUrl { get; set; }
    public required string StoreName { get; set; }
    public required string CustomerOrderId { get; set; }

    public class UpdatePackingSlipCommandHandler : IRequestHandler<UpdatePackingSlipCommand, UpdatedPackingSlipResponse>
    {
        private readonly IMapper _mapper;
        private readonly IPackingSlipRepository _packingSlipRepository;
        private readonly PackingSlipBusinessRules _packingSlipBusinessRules;

        public UpdatePackingSlipCommandHandler(IMapper mapper, IPackingSlipRepository packingSlipRepository,
                                         PackingSlipBusinessRules packingSlipBusinessRules)
        {
            _mapper = mapper;
            _packingSlipRepository = packingSlipRepository;
            _packingSlipBusinessRules = packingSlipBusinessRules;
        }

        public async Task<UpdatedPackingSlipResponse> Handle(UpdatePackingSlipCommand request, CancellationToken cancellationToken)
        {
            PackingSlip? packingSlip = await _packingSlipRepository.GetAsync(predicate: ps => ps.Id == request.Id, cancellationToken: cancellationToken);
            await _packingSlipBusinessRules.PackingSlipShouldExistWhenSelected(packingSlip);
            packingSlip = _mapper.Map(request, packingSlip);

            await _packingSlipRepository.UpdateAsync(packingSlip!);

            UpdatedPackingSlipResponse response = _mapper.Map<UpdatedPackingSlipResponse>(packingSlip);
            return response;
        }
    }
}