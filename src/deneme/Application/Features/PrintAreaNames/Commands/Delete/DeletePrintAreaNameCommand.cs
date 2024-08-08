using Application.Features.PrintAreaNames.Constants;
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

namespace Application.Features.PrintAreaNames.Commands.Delete;

public class DeletePrintAreaNameCommand : IRequest<DeletedPrintAreaNameResponse>, ISecuredRequest, ICacheRemoverRequest, ILoggableRequest, ITransactionalRequest
{
    public Guid Id { get; set; }

    public string[] Roles => [Admin, Write, PrintAreaNamesOperationClaims.Delete];

    public bool BypassCache { get; }
    public string? CacheKey { get; }
    public string[]? CacheGroupKey => ["GetPrintAreaNames"];

    public class DeletePrintAreaNameCommandHandler : IRequestHandler<DeletePrintAreaNameCommand, DeletedPrintAreaNameResponse>
    {
        private readonly IMapper _mapper;
        private readonly IPrintAreaNameRepository _printAreaNameRepository;
        private readonly PrintAreaNameBusinessRules _printAreaNameBusinessRules;

        public DeletePrintAreaNameCommandHandler(IMapper mapper, IPrintAreaNameRepository printAreaNameRepository,
                                         PrintAreaNameBusinessRules printAreaNameBusinessRules)
        {
            _mapper = mapper;
            _printAreaNameRepository = printAreaNameRepository;
            _printAreaNameBusinessRules = printAreaNameBusinessRules;
        }

        public async Task<DeletedPrintAreaNameResponse> Handle(DeletePrintAreaNameCommand request, CancellationToken cancellationToken)
        {
            PrintAreaName? printAreaName = await _printAreaNameRepository.GetAsync(predicate: pan => pan.Id == request.Id, cancellationToken: cancellationToken);
            await _printAreaNameBusinessRules.PrintAreaNameShouldExistWhenSelected(printAreaName);

            await _printAreaNameRepository.DeleteAsync(printAreaName!);

            DeletedPrintAreaNameResponse response = _mapper.Map<DeletedPrintAreaNameResponse>(printAreaName);
            return response;
        }
    }
}