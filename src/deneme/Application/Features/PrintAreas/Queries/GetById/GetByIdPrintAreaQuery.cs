using Application.Features.PrintAreas.Constants;
using Application.Features.PrintAreas.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using NArchitecture.Core.Application.Pipelines.Authorization;
using MediatR;
using static Application.Features.PrintAreas.Constants.PrintAreasOperationClaims;

namespace Application.Features.PrintAreas.Queries.GetById;

public class GetByIdPrintAreaQuery : IRequest<GetByIdPrintAreaResponse>, ISecuredRequest
{
    public Guid Id { get; set; }

    public string[] Roles => [Admin, Read];

    public class GetByIdPrintAreaQueryHandler : IRequestHandler<GetByIdPrintAreaQuery, GetByIdPrintAreaResponse>
    {
        private readonly IMapper _mapper;
        private readonly IPrintAreaRepository _printAreaRepository;
        private readonly PrintAreaBusinessRules _printAreaBusinessRules;

        public GetByIdPrintAreaQueryHandler(IMapper mapper, IPrintAreaRepository printAreaRepository, PrintAreaBusinessRules printAreaBusinessRules)
        {
            _mapper = mapper;
            _printAreaRepository = printAreaRepository;
            _printAreaBusinessRules = printAreaBusinessRules;
        }

        public async Task<GetByIdPrintAreaResponse> Handle(GetByIdPrintAreaQuery request, CancellationToken cancellationToken)
        {
            PrintArea? printArea = await _printAreaRepository.GetAsync(predicate: pa => pa.Id == request.Id, cancellationToken: cancellationToken);
            await _printAreaBusinessRules.PrintAreaShouldExistWhenSelected(printArea);

            GetByIdPrintAreaResponse response = _mapper.Map<GetByIdPrintAreaResponse>(printArea);
            return response;
        }
    }
}