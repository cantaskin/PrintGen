using Application.Features.Categories.Commands.Create;
using Application.Features.Categories.Commands.Delete;
using Application.Features.Categories.Commands.Update;
using Application.Features.Categories.Queries.GetById;
using Application.Features.Categories.Queries.GetList;
using NArchitecture.Core.Application.Requests;
using NArchitecture.Core.Application.Responses;
using Microsoft.AspNetCore.Mvc;
using Infrastructure.Adapters.PrintfulService;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CatalogCategoriesController : BaseController
{
    private readonly PrintfulServiceAdapter _printfulServiceAdapter;

    public CatalogCategoriesController(PrintfulServiceAdapter printfulServiceAdapte)
    {
        _printfulServiceAdapter = printfulServiceAdapte;
    }

    [HttpGet("GetById")]
    public async Task<ActionResult<GetByIdCategoryResponse>> GetById(int id)
    {
        var requestUrl = "https://api.printful.com/v2/catalog-categories/{id}";

        try
        {
            var data = await _printfulServiceAdapter.GetAsync(requestUrl);
            return Ok(data);
        }
        catch (HttpRequestException ex)
        {
            return StatusCode(500, ex.Message);
        }
    }

    [HttpGet("GetAll")]
    public async Task<ActionResult<GetListCategoryQuery>> GetList([FromQuery] PageRequest pageRequest)
    {
        var requestUrl = "https://api.printful.com/v2/catalog-categories";
        
        try
        {
            var data = await _printfulServiceAdapter.GetAsync(requestUrl);
            return Ok(data);
        }
        catch (HttpRequestException ex)
        {
            return StatusCode(500, ex.Message);
        }
    }
}