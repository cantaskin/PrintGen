using Application.Features.PackingSlips.Constants;
using Application.Features.PackingSlips.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.PackingSlips.Commands.Delete;

public class DeletePackingSlipCommand : IRequest<DeletedPackingSlipResponse>
{
    public Guid Id { get; set; }

    public class DeletePackingSlipCommandHandler : IRequestHandler<DeletePackingSlipCommand, DeletedPackingSlipResponse>
    {
        private readonly IMapper _mapper;
        private readonly IPackingSlipRepository _packingSlipRepository;
        private readonly PackingSlipBusinessRules _packingSlipBusinessRules;

        public DeletePackingSlipCommandHandler(IMapper mapper, IPackingSlipRepository packingSlipRepository,
                                         PackingSlipBusinessRules packingSlipBusinessRules)
        {
            _mapper = mapper;
            _packingSlipRepository = packingSlipRepository;
            _packingSlipBusinessRules = packingSlipBusinessRules;
        }

        public async Task<DeletedPackingSlipResponse> Handle(DeletePackingSlipCommand request, CancellationToken cancellationToken)
        {
            PackingSlip? packingSlip = await _packingSlipRepository.GetAsync(predicate: ps => ps.Id == request.Id, cancellationToken: cancellationToken);
            await _packingSlipBusinessRules.PackingSlipShouldExistWhenSelected(packingSlip);

            await _packingSlipRepository.DeleteAsync(packingSlip!);

            DeletedPackingSlipResponse response = _mapper.Map<DeletedPackingSlipResponse>(packingSlip);
            return response;
        }
    }
}