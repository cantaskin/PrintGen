using Application.Features.PrintAreas.Commands.Create;
using Application.Features.PrintAreas.Commands.Delete;
using Application.Features.PrintAreas.Commands.Update;
using Application.Features.PrintAreas.Queries.GetById;
using Application.Features.PrintAreas.Queries.GetList;
using AutoMapper;
using NArchitecture.Core.Application.Responses;
using Domain.Entities;
using NArchitecture.Core.Persistence.Paging;

namespace Application.Features.PrintAreas.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<CreatePrintAreaCommand, PrintArea>();
        CreateMap<PrintArea, CreatedPrintAreaResponse>();

        CreateMap<UpdatePrintAreaCommand, PrintArea>();
        CreateMap<PrintArea, UpdatedPrintAreaResponse>();

        CreateMap<DeletePrintAreaCommand, PrintArea>();
        CreateMap<PrintArea, DeletedPrintAreaResponse>();

        CreateMap<PrintArea, GetByIdPrintAreaResponse>();

        CreateMap<PrintArea, GetListPrintAreaListItemDto>();
        CreateMap<IPaginate<PrintArea>, GetListResponse<GetListPrintAreaListItemDto>>();
    }
}