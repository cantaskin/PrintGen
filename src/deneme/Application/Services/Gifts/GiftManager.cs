using Application.Features.Gifts.Rules;
using Application.Services.Repositories;
using NArchitecture.Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.Gifts;

public class GiftManager : IGiftService
{
    private readonly IGiftRepository _giftRepository;
    private readonly GiftBusinessRules _giftBusinessRules;

    public GiftManager(IGiftRepository giftRepository, GiftBusinessRules giftBusinessRules)
    {
        _giftRepository = giftRepository;
        _giftBusinessRules = giftBusinessRules;
    }

    public async Task<Gift?> GetAsync(
        Expression<Func<Gift, bool>> predicate,
        Func<IQueryable<Gift>, IIncludableQueryable<Gift, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        Gift? gift = await _giftRepository.GetAsync(predicate, include, withDeleted, enableTracking, cancellationToken);
        return gift;
    }

    public async Task<IPaginate<Gift>?> GetListAsync(
        Expression<Func<Gift, bool>>? predicate = null,
        Func<IQueryable<Gift>, IOrderedQueryable<Gift>>? orderBy = null,
        Func<IQueryable<Gift>, IIncludableQueryable<Gift, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        IPaginate<Gift> giftList = await _giftRepository.GetListAsync(
            predicate,
            orderBy,
            include,
            index,
            size,
            withDeleted,
            enableTracking,
            cancellationToken
        );
        return giftList;
    }

    public async Task<Gift> AddAsync(Gift gift)
    {
        Gift addedGift = await _giftRepository.AddAsync(gift);

        return addedGift;
    }

    public async Task<Gift> UpdateAsync(Gift gift)
    {
        Gift updatedGift = await _giftRepository.UpdateAsync(gift);

        return updatedGift;
    }

    public async Task<Gift> DeleteAsync(Gift gift, bool permanent = false)
    {
        Gift deletedGift = await _giftRepository.DeleteAsync(gift);

        return deletedGift;
    }
}
