using Application.Features.PackingSlips.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.PackingSlips.Commands.Create;

public class CreatePackingSlipCommand : IRequest<CreatedPackingSlipResponse>
{
    public required string Email { get; set; }
    public required string Phone { get; set; }
    public required string Message { get; set; }
    public required string LogoUrl { get; set; }
    public required string StoreName { get; set; }
    public required string CustomerOrderId { get; set; }

    public class CreatePackingSlipCommandHandler : IRequestHandler<CreatePackingSlipCommand, CreatedPackingSlipResponse>
    {
        private readonly IMapper _mapper;
        private readonly IPackingSlipRepository _packingSlipRepository;
        private readonly PackingSlipBusinessRules _packingSlipBusinessRules;

        public CreatePackingSlipCommandHandler(IMapper mapper, IPackingSlipRepository packingSlipRepository,
                                         PackingSlipBusinessRules packingSlipBusinessRules)
        {
            _mapper = mapper;
            _packingSlipRepository = packingSlipRepository;
            _packingSlipBusinessRules = packingSlipBusinessRules;
        }

        public async Task<CreatedPackingSlipResponse> Handle(CreatePackingSlipCommand request, CancellationToken cancellationToken)
        {
            PackingSlip packingSlip = _mapper.Map<PackingSlip>(request);

            await _packingSlipRepository.AddAsync(packingSlip);

            CreatedPackingSlipResponse response = _mapper.Map<CreatedPackingSlipResponse>(packingSlip);
            return response;
        }
    }
}