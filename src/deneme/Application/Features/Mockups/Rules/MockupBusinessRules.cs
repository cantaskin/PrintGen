using Application.Features.Addresses.Constants;
using Application.Features.Mockups.Constants;
using Application.Services.Repositories;
using Application.Services.UsersService;
using Domain.Entities;
using Microsoft.AspNetCore.Http;
using NArchitecture.Core.Application.Rules;
using NArchitecture.Core.CrossCuttingConcerns.Exception.Types;
using NArchitecture.Core.Localization.Abstraction;

namespace Application.Features.Mockups.Rules;

public class MockupBusinessRules : BaseBusinessRules
{
    private readonly ILocalizationService _localizationService;
    private readonly IUserService _userService;
    private readonly IHttpContextAccessor _httpContextAccessor;

    public MockupBusinessRules(ILocalizationService localizationService, IUserService userService, IHttpContextAccessor httpContextAccessor)
    {
        _localizationService = localizationService;
        _userService = userService;
        _httpContextAccessor = httpContextAccessor;
    }

    private async Task throwBusinessException(string messageKey)
    {
        string message = await _localizationService.GetLocalizedAsync(messageKey, MockupsBusinessMessages.SectionName);
        throw new BusinessException(message);
    }



}