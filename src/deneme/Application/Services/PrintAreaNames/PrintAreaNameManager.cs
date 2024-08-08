using Application.Features.PrintAreaNames.Rules;
using Application.Services.Repositories;
using NArchitecture.Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.PrintAreaNames;

public class PrintAreaNameManager : IPrintAreaNameService
{
    private readonly IPrintAreaNameRepository _printAreaNameRepository;
    private readonly PrintAreaNameBusinessRules _printAreaNameBusinessRules;

    public PrintAreaNameManager(IPrintAreaNameRepository printAreaNameRepository, PrintAreaNameBusinessRules printAreaNameBusinessRules)
    {
        _printAreaNameRepository = printAreaNameRepository;
        _printAreaNameBusinessRules = printAreaNameBusinessRules;
    }

    public async Task<PrintAreaName?> GetAsync(
        Expression<Func<PrintAreaName, bool>> predicate,
        Func<IQueryable<PrintAreaName>, IIncludableQueryable<PrintAreaName, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        PrintAreaName? printAreaName = await _printAreaNameRepository.GetAsync(predicate, include, withDeleted, enableTracking, cancellationToken);
        return printAreaName;
    }

    public async Task<IPaginate<PrintAreaName>?> GetListAsync(
        Expression<Func<PrintAreaName, bool>>? predicate = null,
        Func<IQueryable<PrintAreaName>, IOrderedQueryable<PrintAreaName>>? orderBy = null,
        Func<IQueryable<PrintAreaName>, IIncludableQueryable<PrintAreaName, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        IPaginate<PrintAreaName> printAreaNameList = await _printAreaNameRepository.GetListAsync(
            predicate,
            orderBy,
            include,
            index,
            size,
            withDeleted,
            enableTracking,
            cancellationToken
        );
        return printAreaNameList;
    }

    public async Task<PrintAreaName> AddAsync(PrintAreaName printAreaName)
    {
        PrintAreaName addedPrintAreaName = await _printAreaNameRepository.AddAsync(printAreaName);

        return addedPrintAreaName;
    }

    public async Task<PrintAreaName> UpdateAsync(PrintAreaName printAreaName)
    {
        PrintAreaName updatedPrintAreaName = await _printAreaNameRepository.UpdateAsync(printAreaName);

        return updatedPrintAreaName;
    }

    public async Task<PrintAreaName> DeleteAsync(PrintAreaName printAreaName, bool permanent = false)
    {
        PrintAreaName deletedPrintAreaName = await _printAreaNameRepository.DeleteAsync(printAreaName);

        return deletedPrintAreaName;
    }
}
