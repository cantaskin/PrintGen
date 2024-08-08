using Application.Features.Colors.Constants;
using Application.Features.Colors.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using NArchitecture.Core.Application.Pipelines.Authorization;
using NArchitecture.Core.Application.Pipelines.Caching;
using NArchitecture.Core.Application.Pipelines.Logging;
using NArchitecture.Core.Application.Pipelines.Transaction;
using MediatR;
using static Application.Features.Colors.Constants.ColorsOperationClaims;

namespace Application.Features.Colors.Commands.Update;

public class UpdateColorCommand : IRequest<UpdatedColorResponse>, ISecuredRequest, ICacheRemoverRequest, ILoggableRequest, ITransactionalRequest
{
    public Guid Id { get; set; }
    public required string ColorName { get; set; }

    public string[] Roles => [Admin, Write, ColorsOperationClaims.Update];

    public bool BypassCache { get; }
    public string? CacheKey { get; }
    public string[]? CacheGroupKey => ["GetColors"];

    public class UpdateColorCommandHandler : IRequestHandler<UpdateColorCommand, UpdatedColorResponse>
    {
        private readonly IMapper _mapper;
        private readonly IColorRepository _colorRepository;
        private readonly ColorBusinessRules _colorBusinessRules;

        public UpdateColorCommandHandler(IMapper mapper, IColorRepository colorRepository,
                                         ColorBusinessRules colorBusinessRules)
        {
            _mapper = mapper;
            _colorRepository = colorRepository;
            _colorBusinessRules = colorBusinessRules;
        }

        public async Task<UpdatedColorResponse> Handle(UpdateColorCommand request, CancellationToken cancellationToken)
        {
            Color? color = await _colorRepository.GetAsync(predicate: c => c.Id == request.Id, cancellationToken: cancellationToken);
            await _colorBusinessRules.ColorShouldExistWhenSelected(color);
            color = _mapper.Map(request, color);

            await _colorRepository.UpdateAsync(color!);

            UpdatedColorResponse response = _mapper.Map<UpdatedColorResponse>(color);
            return response;
        }
    }
}