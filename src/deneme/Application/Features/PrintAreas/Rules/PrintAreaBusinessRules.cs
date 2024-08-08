using Application.Features.PrintAreas.Constants;
using Application.Services.Repositories;
using NArchitecture.Core.Application.Rules;
using NArchitecture.Core.CrossCuttingConcerns.Exception.Types;
using NArchitecture.Core.Localization.Abstraction;
using Domain.Entities;

namespace Application.Features.PrintAreas.Rules;

public class PrintAreaBusinessRules : BaseBusinessRules
{
    private readonly IPrintAreaRepository _printAreaRepository;
    private readonly ILocalizationService _localizationService;

    public PrintAreaBusinessRules(IPrintAreaRepository printAreaRepository, ILocalizationService localizationService)
    {
        _printAreaRepository = printAreaRepository;
        _localizationService = localizationService;
    }

    private async Task throwBusinessException(string messageKey)
    {
        string message = await _localizationService.GetLocalizedAsync(messageKey, PrintAreasBusinessMessages.SectionName);
        throw new BusinessException(message);
    }

    public async Task PrintAreaShouldExistWhenSelected(PrintArea? printArea)
    {
        if (printArea == null)
            await throwBusinessException(PrintAreasBusinessMessages.PrintAreaNotExists);
    }

    public async Task PrintAreaIdShouldExistWhenSelected(Guid id, CancellationToken cancellationToken)
    {
        PrintArea? printArea = await _printAreaRepository.GetAsync(
            predicate: pa => pa.Id == id,
            enableTracking: false,
            cancellationToken: cancellationToken
        );
        await PrintAreaShouldExistWhenSelected(printArea);
    }
}