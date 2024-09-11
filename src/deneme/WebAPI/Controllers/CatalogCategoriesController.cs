using NArchitecture.Core.Application.Requests;
using NArchitecture.Core.Application.Responses;
using Microsoft.AspNetCore.Mvc;
using Infrastructure.Adapters.PrintfulService;

namespace WebAPI.Controllers;

[Route("api/catalogcategory")]
[ApiController]
public class CatalogCategoriesController : BaseController
{
    private readonly PrintfulServiceAdapter _printfulServiceAdapter;

    public CatalogCategoriesController(PrintfulServiceAdapter printfulServiceAdapte)
    {
        _printfulServiceAdapter = printfulServiceAdapte;
    }

    [HttpGet("{id}")]

    public async Task<ActionResult> GetById(int id)
    {
       var requestUrl = $"https://api.printful.com/v2/catalog-categories/{id}";

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

    [HttpGet()]
    public async Task<ActionResult> GetList([FromQuery] PageRequest pageRequest)
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