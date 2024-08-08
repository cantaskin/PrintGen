using Application.Features.PrintAreas.Rules;
using Application.Services.Repositories;
using NArchitecture.Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.PrintAreas;

public class PrintAreaManager : IPrintAreaService
{
    private readonly IPrintAreaRepository _printAreaRepository;
    private readonly PrintAreaBusinessRules _printAreaBusinessRules;

    public PrintAreaManager(IPrintAreaRepository printAreaRepository, PrintAreaBusinessRules printAreaBusinessRules)
    {
        _printAreaRepository = printAreaRepository;
        _printAreaBusinessRules = printAreaBusinessRules;
    }

    public async Task<PrintArea?> GetAsync(
        Expression<Func<PrintArea, bool>> predicate,
        Func<IQueryable<PrintArea>, IIncludableQueryable<PrintArea, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        PrintArea? printArea = await _printAreaRepository.GetAsync(predicate, include, withDeleted, enableTracking, cancellationToken);
        return printArea;
    }

    public async Task<IPaginate<PrintArea>?> GetListAsync(
        Expression<Func<PrintArea, bool>>? predicate = null,
        Func<IQueryable<PrintArea>, IOrderedQueryable<PrintArea>>? orderBy = null,
        Func<IQueryable<PrintArea>, IIncludableQueryable<PrintArea, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        IPaginate<PrintArea> printAreaList = await _printAreaRepository.GetListAsync(
            predicate,
            orderBy,
            include,
            index,
            size,
            withDeleted,
            enableTracking,
            cancellationToken
        );
        return printAreaList;
    }

    public async Task<PrintArea> AddAsync(PrintArea printArea)
    {
        PrintArea addedPrintArea = await _printAreaRepository.AddAsync(printArea);

        return addedPrintArea;
    }

    public async Task<PrintArea> UpdateAsync(PrintArea printArea)
    {
        PrintArea updatedPrintArea = await _printAreaRepository.UpdateAsync(printArea);

        return updatedPrintArea;
    }

    public async Task<PrintArea> DeleteAsync(PrintArea printArea, bool permanent = false)
    {
        PrintArea deletedPrintArea = await _printAreaRepository.DeleteAsync(printArea);

        return deletedPrintArea;
    }
}
