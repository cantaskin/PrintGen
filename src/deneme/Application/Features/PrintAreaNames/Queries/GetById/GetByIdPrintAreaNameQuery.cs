using Application.Features.PrintAreaNames.Constants;
using Application.Features.PrintAreaNames.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using NArchitecture.Core.Application.Pipelines.Authorization;
using MediatR;
using static Application.Features.PrintAreaNames.Constants.PrintAreaNamesOperationClaims;

namespace Application.Features.PrintAreaNames.Queries.GetById;

public class GetByIdPrintAreaNameQuery : IRequest<GetByIdPrintAreaNameResponse>, ISecuredRequest
{
    public Guid Id { get; set; }

    public string[] Roles => [Admin, Read];

    public class GetByIdPrintAreaNameQueryHandler : IRequestHandler<GetByIdPrintAreaNameQuery, GetByIdPrintAreaNameResponse>
    {
        private readonly IMapper _mapper;
        private readonly IPrintAreaNameRepository _printAreaNameRepository;
        private readonly PrintAreaNameBusinessRules _printAreaNameBusinessRules;

        public GetByIdPrintAreaNameQueryHandler(IMapper mapper, IPrintAreaNameRepository printAreaNameRepository, PrintAreaNameBusinessRules printAreaNameBusinessRules)
        {
            _mapper = mapper;
            _printAreaNameRepository = printAreaNameRepository;
            _printAreaNameBusinessRules = printAreaNameBusinessRules;
        }

        public async Task<GetByIdPrintAreaNameResponse> Handle(GetByIdPrintAreaNameQuery request, CancellationToken cancellationToken)
        {
            PrintAreaName? printAreaName = await _printAreaNameRepository.GetAsync(predicate: pan => pan.Id == request.Id, cancellationToken: cancellationToken);
            await _printAreaNameBusinessRules.PrintAreaNameShouldExistWhenSelected(printAreaName);

            GetByIdPrintAreaNameResponse response = _mapper.Map<GetByIdPrintAreaNameResponse>(printAreaName);
            return response;
        }
    }
}