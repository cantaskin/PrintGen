using Application.Features.Gifts.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.Gifts.Commands.Create;

public class CreateGiftCommand : IRequest<CreatedGiftResponse>
{
    public required string Subject { get; set; }
    public required string Message { get; set; }

    public class CreateGiftCommandHandler : IRequestHandler<CreateGiftCommand, CreatedGiftResponse>
    {
        private readonly IMapper _mapper;
        private readonly IGiftRepository _giftRepository;
        private readonly GiftBusinessRules _giftBusinessRules;

        public CreateGiftCommandHandler(IMapper mapper, IGiftRepository giftRepository,
                                         GiftBusinessRules giftBusinessRules)
        {
            _mapper = mapper;
            _giftRepository = giftRepository;
            _giftBusinessRules = giftBusinessRules;
        }

        public async Task<CreatedGiftResponse> Handle(CreateGiftCommand request, CancellationToken cancellationToken)
        {
            Gift gift = _mapper.Map<Gift>(request);

            await _giftRepository.AddAsync(gift);

            CreatedGiftResponse response = _mapper.Map<CreatedGiftResponse>(gift);
            return response;
        }
    }
}