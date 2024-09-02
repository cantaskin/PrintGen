using Application.Features.PackingSlips.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.PackingSlips.Queries.GetById;

public class GetByIdPackingSlipQuery : IRequest<GetByIdPackingSlipResponse>
{
    public Guid Id { get; set; }

    public class GetByIdPackingSlipQueryHandler : IRequestHandler<GetByIdPackingSlipQuery, GetByIdPackingSlipResponse>
    {
        private readonly IMapper _mapper;
        private readonly IPackingSlipRepository _packingSlipRepository;
        private readonly PackingSlipBusinessRules _packingSlipBusinessRules;

        public GetByIdPackingSlipQueryHandler(IMapper mapper, IPackingSlipRepository packingSlipRepository, PackingSlipBusinessRules packingSlipBusinessRules)
        {
            _mapper = mapper;
            _packingSlipRepository = packingSlipRepository;
            _packingSlipBusinessRules = packingSlipBusinessRules;
        }

        public async Task<GetByIdPackingSlipResponse> Handle(GetByIdPackingSlipQuery request, CancellationToken cancellationToken)
        {
            PackingSlip? packingSlip = await _packingSlipRepository.GetAsync(predicate: ps => ps.Id == request.Id, cancellationToken: cancellationToken);
            await _packingSlipBusinessRules.PackingSlipShouldExistWhenSelected(packingSlip);

            GetByIdPackingSlipResponse response = _mapper.Map<GetByIdPackingSlipResponse>(packingSlip);
            return response;
        }
    }
}