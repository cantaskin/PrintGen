using Application.Features.PrintAreaNames.Constants;
using Application.Services.Repositories;
using NArchitecture.Core.Application.Rules;
using NArchitecture.Core.CrossCuttingConcerns.Exception.Types;
using NArchitecture.Core.Localization.Abstraction;
using Domain.Entities;

namespace Application.Features.PrintAreaNames.Rules;

public class PrintAreaNameBusinessRules : BaseBusinessRules
{
    private readonly IPrintAreaNameRepository _printAreaNameRepository;
    private readonly ILocalizationService _localizationService;

    public PrintAreaNameBusinessRules(IPrintAreaNameRepository printAreaNameRepository, ILocalizationService localizationService)
    {
        _printAreaNameRepository = printAreaNameRepository;
        _localizationService = localizationService;
    }

    private async Task throwBusinessException(string messageKey)
    {
        string message = await _localizationService.GetLocalizedAsync(messageKey, PrintAreaNamesBusinessMessages.SectionName);
        throw new BusinessException(message);
    }

    public async Task PrintAreaNameShouldExistWhenSelected(PrintAreaName? printAreaName)
    {
        if (printAreaName == null)
            await throwBusinessException(PrintAreaNamesBusinessMessages.PrintAreaNameNotExists);
    }

    public async Task PrintAreaNameIdShouldExistWhenSelected(Guid id, CancellationToken cancellationToken)
    {
        PrintAreaName? printAreaName = await _printAreaNameRepository.GetAsync(
            predicate: pan => pan.Id == id,
            enableTracking: false,
            cancellationToken: cancellationToken
        );
        await PrintAreaNameShouldExistWhenSelected(printAreaName);
    }
}