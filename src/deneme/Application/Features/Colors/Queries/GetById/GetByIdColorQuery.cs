using Application.Features.Colors.Constants;
using Application.Features.Colors.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using NArchitecture.Core.Application.Pipelines.Authorization;
using MediatR;
using static Application.Features.Colors.Constants.ColorsOperationClaims;

namespace Application.Features.Colors.Queries.GetById;

public class GetByIdColorQuery : IRequest<GetByIdColorResponse>
{
    public Guid Id { get; set; }

    public class GetByIdColorQueryHandler : IRequestHandler<GetByIdColorQuery, GetByIdColorResponse>
    {
        private readonly IMapper _mapper;
        private readonly IColorRepository _colorRepository;
        private readonly ColorBusinessRules _colorBusinessRules;

        public GetByIdColorQueryHandler(IMapper mapper, IColorRepository colorRepository, ColorBusinessRules colorBusinessRules)
        {
            _mapper = mapper;
            _colorRepository = colorRepository;
            _colorBusinessRules = colorBusinessRules;
        }

        public async Task<GetByIdColorResponse> Handle(GetByIdColorQuery request, CancellationToken cancellationToken)
        {
            Color? color = await _colorRepository.GetAsync(predicate: c => c.Id == request.Id, cancellationToken: cancellationToken);
            await _colorBusinessRules.ColorShouldExistWhenSelected(color);

            GetByIdColorResponse response = _mapper.Map<GetByIdColorResponse>(color);
            return response;
        }
    }
}