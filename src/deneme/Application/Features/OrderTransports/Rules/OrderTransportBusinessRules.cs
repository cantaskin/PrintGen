using Application.Features.OrderTransports.Constants;
using Application.Services.Repositories;
using NArchitecture.Core.Application.Rules;
using NArchitecture.Core.CrossCuttingConcerns.Exception.Types;
using NArchitecture.Core.Localization.Abstraction;
using Domain.Entities;

namespace Application.Features.OrderTransports.Rules;

public class OrderTransportBusinessRules : BaseBusinessRules
{
    private readonly IOrderTransportRepository _orderTransportRepository;
    private readonly ILocalizationService _localizationService;

    public OrderTransportBusinessRules(IOrderTransportRepository orderTransportRepository, ILocalizationService localizationService)
    {
        _orderTransportRepository = orderTransportRepository;
        _localizationService = localizationService;
    }

    private async Task throwBusinessException(string messageKey)
    {
        string message = await _localizationService.GetLocalizedAsync(messageKey, OrderTransportsBusinessMessages.SectionName);
        throw new BusinessException(message);
    }

    public async Task OrderTransportShouldExistWhenSelected(OrderTransport? orderTransport)
    {
        if (orderTransport == null)
            await throwBusinessException(OrderTransportsBusinessMessages.OrderTransportNotExists);
    }

    public async Task OrderTransportIdShouldExistWhenSelected(Guid id, CancellationToken cancellationToken)
    {
        OrderTransport? orderTransport = await _orderTransportRepository.GetAsync(
            predicate: ot => ot.Id == id,
            enableTracking: false,
            cancellationToken: cancellationToken
        );
        await OrderTransportShouldExistWhenSelected(orderTransport);
    }
}