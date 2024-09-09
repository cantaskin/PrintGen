using Application.Features.Options.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.Options.Queries.GetById;

public class GetByIdOptionQuery : IRequest<GetByIdOptionResponse>
{
    public Guid Id { get; set; }

    public class GetByIdOptionQueryHandler : IRequestHandler<GetByIdOptionQuery, GetByIdOptionResponse>
    {
        private readonly IMapper _mapper;
        private readonly IOptionRepository _optionRepository;
        private readonly OptionBusinessRules _optionBusinessRules;

        public GetByIdOptionQueryHandler(IMapper mapper, IOptionRepository optionRepository, OptionBusinessRules optionBusinessRules)
        {
            _mapper = mapper;
            _optionRepository = optionRepository;
            _optionBusinessRules = optionBusinessRules;
        }

        public async Task<GetByIdOptionResponse> Handle(GetByIdOptionQuery request, CancellationToken cancellationToken)
        {
            Option? option = await _optionRepository.GetAsync(predicate: o => o.Id == request.Id, cancellationToken: cancellationToken);
            await _optionBusinessRules.OptionShouldExistWhenSelected(option);

            GetByIdOptionResponse response = _mapper.Map<GetByIdOptionResponse>(option);
            return response;
        }
    }
}