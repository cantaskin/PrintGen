using Application.Features.PrintAreaNames.Commands.Create;
using Application.Features.PrintAreaNames.Commands.Delete;
using Application.Features.PrintAreaNames.Commands.Update;
using Application.Features.PrintAreaNames.Queries.GetById;
using Application.Features.PrintAreaNames.Queries.GetList;
using AutoMapper;
using NArchitecture.Core.Application.Responses;
using Domain.Entities;
using NArchitecture.Core.Persistence.Paging;

namespace Application.Features.PrintAreaNames.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<CreatePrintAreaNameCommand, PrintAreaName>();
        CreateMap<PrintAreaName, CreatedPrintAreaNameResponse>();

        CreateMap<UpdatePrintAreaNameCommand, PrintAreaName>();
        CreateMap<PrintAreaName, UpdatedPrintAreaNameResponse>();

        CreateMap<DeletePrintAreaNameCommand, PrintAreaName>();
        CreateMap<PrintAreaName, DeletedPrintAreaNameResponse>();

        CreateMap<PrintAreaName, GetByIdPrintAreaNameResponse>();

        CreateMap<PrintAreaName, GetListPrintAreaNameListItemDto>();
        CreateMap<IPaginate<PrintAreaName>, GetListResponse<GetListPrintAreaNameListItemDto>>();
    }
}