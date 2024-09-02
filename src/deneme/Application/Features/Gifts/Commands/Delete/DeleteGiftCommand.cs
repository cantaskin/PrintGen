using Application.Features.Gifts.Constants;
using Application.Features.Gifts.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.Gifts.Commands.Delete;

public class DeleteGiftCommand : IRequest<DeletedGiftResponse>
{
    public Guid Id { get; set; }

    public class DeleteGiftCommandHandler : IRequestHandler<DeleteGiftCommand, DeletedGiftResponse>
    {
        private readonly IMapper _mapper;
        private readonly IGiftRepository _giftRepository;
        private readonly GiftBusinessRules _giftBusinessRules;

        public DeleteGiftCommandHandler(IMapper mapper, IGiftRepository giftRepository,
                                         GiftBusinessRules giftBusinessRules)
        {
            _mapper = mapper;
            _giftRepository = giftRepository;
            _giftBusinessRules = giftBusinessRules;
        }

        public async Task<DeletedGiftResponse> Handle(DeleteGiftCommand request, CancellationToken cancellationToken)
        {
            Gift? gift = await _giftRepository.GetAsync(predicate: g => g.Id == request.Id, cancellationToken: cancellationToken);
            await _giftBusinessRules.GiftShouldExistWhenSelected(gift);

            await _giftRepository.DeleteAsync(gift!);

            DeletedGiftResponse response = _mapper.Map<DeletedGiftResponse>(gift);
            return response;
        }
    }
}