using Application.Features.PrintAreaNames.Constants;
using Application.Features.PrintAreaNames.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using NArchitecture.Core.Application.Pipelines.Authorization;
using NArchitecture.Core.Application.Pipelines.Caching;
using NArchitecture.Core.Application.Pipelines.Logging;
using NArchitecture.Core.Application.Pipelines.Transaction;
using MediatR;
using static Application.Features.PrintAreaNames.Constants.PrintAreaNamesOperationClaims;

namespace Application.Features.PrintAreaNames.Commands.Create;

public class CreatePrintAreaNameCommand : IRequest<CreatedPrintAreaNameResponse>, ISecuredRequest, ICacheRemoverRequest, ILoggableRequest, ITransactionalRequest
{
    public required string Name { get; set; }

    public string[] Roles => [Admin, Write, PrintAreaNamesOperationClaims.Create];

    public bool BypassCache { get; }
    public string? CacheKey { get; }
    public string[]? CacheGroupKey => ["GetPrintAreaNames"];

    public class CreatePrintAreaNameCommandHandler : IRequestHandler<CreatePrintAreaNameCommand, CreatedPrintAreaNameResponse>
    {
        private readonly IMapper _mapper;
        private readonly IPrintAreaNameRepository _printAreaNameRepository;
        private readonly PrintAreaNameBusinessRules _printAreaNameBusinessRules;

        public CreatePrintAreaNameCommandHandler(IMapper mapper, IPrintAreaNameRepository printAreaNameRepository,
                                         PrintAreaNameBusinessRules printAreaNameBusinessRules)
        {
            _mapper = mapper;
            _printAreaNameRepository = printAreaNameRepository;
            _printAreaNameBusinessRules = printAreaNameBusinessRules;
        }

        public async Task<CreatedPrintAreaNameResponse> Handle(CreatePrintAreaNameCommand request, CancellationToken cancellationToken)
        {
            PrintAreaName printAreaName = _mapper.Map<PrintAreaName>(request);

            await _printAreaNameRepository.AddAsync(printAreaName);

            CreatedPrintAreaNameResponse response = _mapper.Map<CreatedPrintAreaNameResponse>(printAreaName);
            return response;
        }
    }
}