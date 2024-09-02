using Application.Features.Gifts.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.Gifts.Commands.Update;

public class UpdateGiftCommand : IRequest<UpdatedGiftResponse>
{
    public Guid Id { get; set; }
    public required string Subject { get; set; }
    public required string Message { get; set; }

    public class UpdateGiftCommandHandler : IRequestHandler<UpdateGiftCommand, UpdatedGiftResponse>
    {
        private readonly IMapper _mapper;
        private readonly IGiftRepository _giftRepository;
        private readonly GiftBusinessRules _giftBusinessRules;

        public UpdateGiftCommandHandler(IMapper mapper, IGiftRepository giftRepository,
                                         GiftBusinessRules giftBusinessRules)
        {
            _mapper = mapper;
            _giftRepository = giftRepository;
            _giftBusinessRules = giftBusinessRules;
        }

        public async Task<UpdatedGiftResponse> Handle(UpdateGiftCommand request, CancellationToken cancellationToken)
        {
            Gift? gift = await _giftRepository.GetAsync(predicate: g => g.Id == request.Id, cancellationToken: cancellationToken);
            await _giftBusinessRules.GiftShouldExistWhenSelected(gift);
            gift = _mapper.Map(request, gift);

            await _giftRepository.UpdateAsync(gift!);

            UpdatedGiftResponse response = _mapper.Map<UpdatedGiftResponse>(gift);
            return response;
        }
    }
}