using Application.Features.PrintAreas.Constants;
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

namespace Application.Features.PrintAreas.Commands.Delete;

public class DeletePrintAreaCommand : IRequest<DeletedPrintAreaResponse>, ISecuredRequest, ICacheRemoverRequest, ILoggableRequest, ITransactionalRequest
{
    public Guid Id { get; set; }

    public string[] Roles => [Admin, Write, PrintAreasOperationClaims.Delete];

    public bool BypassCache { get; }
    public string? CacheKey { get; }
    public string[]? CacheGroupKey => ["GetPrintAreas"];

    public class DeletePrintAreaCommandHandler : IRequestHandler<DeletePrintAreaCommand, DeletedPrintAreaResponse>
    {
        private readonly IMapper _mapper;
        private readonly IPrintAreaRepository _printAreaRepository;
        private readonly PrintAreaBusinessRules _printAreaBusinessRules;

        public DeletePrintAreaCommandHandler(IMapper mapper, IPrintAreaRepository printAreaRepository,
                                         PrintAreaBusinessRules printAreaBusinessRules)
        {
            _mapper = mapper;
            _printAreaRepository = printAreaRepository;
            _printAreaBusinessRules = printAreaBusinessRules;
        }

        public async Task<DeletedPrintAreaResponse> Handle(DeletePrintAreaCommand request, CancellationToken cancellationToken)
        {
            PrintArea? printArea = await _printAreaRepository.GetAsync(predicate: pa => pa.Id == request.Id, cancellationToken: cancellationToken);
            await _printAreaBusinessRules.PrintAreaShouldExistWhenSelected(printArea);

            await _printAreaRepository.DeleteAsync(printArea!);

            DeletedPrintAreaResponse response = _mapper.Map<DeletedPrintAreaResponse>(printArea);
            return response;
        }
    }
}