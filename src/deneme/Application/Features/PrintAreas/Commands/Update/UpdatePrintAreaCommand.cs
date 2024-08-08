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

namespace Application.Features.PrintAreas.Commands.Update;

public class UpdatePrintAreaCommand : IRequest<UpdatedPrintAreaResponse>, ISecuredRequest, ICacheRemoverRequest, ILoggableRequest, ITransactionalRequest
{
    public Guid Id { get; set; }
    public required Guid PrintAreaNameId { get; set; }
    public required Guid ProductId { get; set; }
    public Guid? CustomizedImageId { get; set; }
    public required int X { get; set; }
    public required int Y { get; set; }

    public string[] Roles => [Admin, Write, PrintAreasOperationClaims.Update];

    public bool BypassCache { get; }
    public string? CacheKey { get; }
    public string[]? CacheGroupKey => ["GetPrintAreas"];

    public class UpdatePrintAreaCommandHandler : IRequestHandler<UpdatePrintAreaCommand, UpdatedPrintAreaResponse>
    {
        private readonly IMapper _mapper;
        private readonly IPrintAreaRepository _printAreaRepository;
        private readonly PrintAreaBusinessRules _printAreaBusinessRules;

        public UpdatePrintAreaCommandHandler(IMapper mapper, IPrintAreaRepository printAreaRepository,
                                         PrintAreaBusinessRules printAreaBusinessRules)
        {
            _mapper = mapper;
            _printAreaRepository = printAreaRepository;
            _printAreaBusinessRules = printAreaBusinessRules;
        }

        public async Task<UpdatedPrintAreaResponse> Handle(UpdatePrintAreaCommand request, CancellationToken cancellationToken)
        {
            PrintArea? printArea = await _printAreaRepository.GetAsync(predicate: pa => pa.Id == request.Id, cancellationToken: cancellationToken);
            await _printAreaBusinessRules.PrintAreaShouldExistWhenSelected(printArea);
            printArea = _mapper.Map(request, printArea);

            await _printAreaRepository.UpdateAsync(printArea!);

            UpdatedPrintAreaResponse response = _mapper.Map<UpdatedPrintAreaResponse>(printArea);
            return response;
        }
    }
}