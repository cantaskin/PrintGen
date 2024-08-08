using Application.Features.PrintAreas.Constants;
using Application.Features.PrintAreas.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using NArchitecture.Core.Application.Pipelines.Authorization;
using NArchitecture.Core.Application.Pipelines.Caching;
using NArchitecture.Core.Application.Pipelines.Logging;
using NArchitecture.Core.Application.Pipelines.Transaction;
using MediatR;
using static Application.Features.PrintAreas.Constants.PrintAreasOperationClaims;
using System.Drawing;

namespace Application.Features.PrintAreas.Commands.Create;

public class CreatePrintAreaCommand : IRequest<CreatedPrintAreaResponse>, ISecuredRequest, ICacheRemoverRequest, ILoggableRequest, ITransactionalRequest
{
    public required Guid PrintAreaNameId { get; set; }
    public required Guid ProductId { get; set; }
    public required int X { get; set; }
    public required int Y { get; set; }

    public string[] Roles => [Admin, Write, PrintAreasOperationClaims.Create];

    public bool BypassCache { get; }
    public string? CacheKey { get; }
    public string[]? CacheGroupKey => ["GetPrintAreas"];

    public class CreatePrintAreaCommandHandler : IRequestHandler<CreatePrintAreaCommand, CreatedPrintAreaResponse>
    {
        private readonly IMapper _mapper;
        private readonly IPrintAreaRepository _printAreaRepository;
        private readonly PrintAreaBusinessRules _printAreaBusinessRules;

        public CreatePrintAreaCommandHandler(IMapper mapper, IPrintAreaRepository printAreaRepository,
                                         PrintAreaBusinessRules printAreaBusinessRules)
        {
            _mapper = mapper;
            _printAreaRepository = printAreaRepository;
            _printAreaBusinessRules = printAreaBusinessRules;
        }

        public async Task<CreatedPrintAreaResponse> Handle(CreatePrintAreaCommand request, CancellationToken cancellationToken)
        {
            PrintArea printArea = _mapper.Map<PrintArea>(request);

            await _printAreaRepository.AddAsync(printArea);

            CreatedPrintAreaResponse response = _mapper.Map<CreatedPrintAreaResponse>(printArea);
            return response;
        }
    }
}