using Application.Features.Gifts.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.Gifts.Queries.GetById;

public class GetByIdGiftQuery : IRequest<GetByIdGiftResponse>
{
    public Guid Id { get; set; }

    public class GetByIdGiftQueryHandler : IRequestHandler<GetByIdGiftQuery, GetByIdGiftResponse>
    {
        private readonly IMapper _mapper;
        private readonly IGiftRepository _giftRepository;
        private readonly GiftBusinessRules _giftBusinessRules;

        public GetByIdGiftQueryHandler(IMapper mapper, IGiftRepository giftRepository, GiftBusinessRules giftBusinessRules)
        {
            _mapper = mapper;
            _giftRepository = giftRepository;
            _giftBusinessRules = giftBusinessRules;
        }

        public async Task<GetByIdGiftResponse> Handle(GetByIdGiftQuery request, CancellationToken cancellationToken)
        {
            Gift? gift = await _giftRepository.GetAsync(predicate: g => g.Id == request.Id, cancellationToken: cancellationToken);
            await _giftBusinessRules.GiftShouldExistWhenSelected(gift);

            GetByIdGiftResponse response = _mapper.Map<GetByIdGiftResponse>(gift);
            return response;
        }
    }
}