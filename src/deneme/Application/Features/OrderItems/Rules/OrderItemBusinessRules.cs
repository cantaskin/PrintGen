using Application.Features.OrderItems.Constants;
using Application.Services.Repositories;
using NArchitecture.Core.Application.Rules;
using NArchitecture.Core.CrossCuttingConcerns.Exception.Types;
using NArchitecture.Core.Localization.Abstraction;
using Domain.Entities;

namespace Application.Features.OrderItems.Rules;

public class OrderItemBusinessRules : BaseBusinessRules
{
    private readonly IOrderItemRepository _orderItemRepository;
    private readonly ILocalizationService _localizationService;

    public OrderItemBusinessRules(IOrderItemRepository orderItemRepository, ILocalizationService localizationService)
    {
        _orderItemRepository = orderItemRepository;
        _localizationService = localizationService;
    }

    private async Task throwBusinessException(string messageKey)
    {
        string message = await _localizationService.GetLocalizedAsync(messageKey, OrderItemsBusinessMessages.SectionName);
        throw new BusinessException(message);
    }

    public async Task OrderItemShouldExistWhenSelected(OrderItem? orderItem)
    {
        if (orderItem == null)
            await throwBusinessException(OrderItemsBusinessMessages.OrderItemNotExists);
    }

    public async Task OrderItemIdShouldExistWhenSelected(Guid id, CancellationToken cancellationToken)
    {
        OrderItem? orderItem = await _orderItemRepository.GetAsync(
            predicate: oi => oi.Id == id,
            enableTracking: false,
            cancellationToken: cancellationToken
        );
        await OrderItemShouldExistWhenSelected(orderItem);
    }
}