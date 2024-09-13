using Application.Features.Addresses.Constants;
using Application.Services.Repositories;
using Application.Services.UsersService;
using NArchitecture.Core.Application.Rules;
using NArchitecture.Core.CrossCuttingConcerns.Exception.Types;
using NArchitecture.Core.Localization.Abstraction;
using Domain.Entities;
using Microsoft.AspNetCore.Http;
using NArchitecture.Core.Security.Constants;

namespace Application.Features.Addresses.Rules;

public class AddressBusinessRules : BaseBusinessRules
{
    private readonly IAddressRepository _addressRepository;
    private readonly ILocalizationService _localizationService;
    private readonly IUserService _userService;
    private readonly IHttpContextAccessor _httpContextAccessor;

    public AddressBusinessRules(IAddressRepository addressRepository, ILocalizationService localizationService, IUserService userService, IHttpContextAccessor httpContextAccessor)
    {
        _addressRepository = addressRepository;
        _localizationService = localizationService;
        _userService = userService;
        _httpContextAccessor = httpContextAccessor;
    }

    private async Task throwBusinessException(string messageKey)
    {
        string message = await _localizationService.GetLocalizedAsync(messageKey, AddressesBusinessMessages.SectionName);
        throw new BusinessException(message);
    }

    public async Task AddressShouldExistWhenSelected(Address? address)
    {
        if (address == null)
            await throwBusinessException(AddressesBusinessMessages.AddressNotExists);
    }

    public async Task AddressIdShouldExistWhenSelected(Guid id, CancellationToken cancellationToken)
    {
        Address? address = await _addressRepository.GetAsync(
            predicate: a => a.Id == id,
            enableTracking: false,
            cancellationToken: cancellationToken
        );
        await AddressShouldExistWhenSelected(address);
    }

}