using Infrastructure.Adapters.PrintfulService;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http.Headers;
using WebAPI.Controllers;

namespace WebAPI;

[Route("api/[controller]")]
[ApiController]
public class CatalogVariantsController : BaseController
{
    private readonly PrintfulServiceAdapter _printfulServiceAdapter;

    public CatalogVariantsController(PrintfulServiceAdapter printfulServiceAdapte)
    {
        _printfulServiceAdapter = printfulServiceAdapte;
    }

    [HttpGet("GetById")]
    public async Task<IActionResult> GetById(int id)
    {
        var requestUrl = "https://api.printful.com/v2/catalog-variants/{id}";

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
    public async Task<IActionResult> GetList(
       [FromQuery] List<int> category_ids,
       [FromQuery] string? colors,
       [FromQuery] int limit = 20,
       [FromQuery] bool @new = false,
       [FromQuery] int offset = 0,
       [FromQuery] List<string>? placements = null,
       [FromQuery] string selling_region_name = "worldwide",
       [FromQuery] string sort_direction = "descending",
       [FromQuery] string? sort_type = null,
       [FromQuery] List<string>? techniques = null)
    {
        var requestUrl = "https://api.printful.com/v2/catalog-products";

        // Add query parameters
        var queryParameters = new List<string>();
        if (category_ids != null && category_ids.Count > 0)
            queryParameters.Add($"category_ids={string.Join(",", category_ids)}");
        if (!string.IsNullOrEmpty(colors))
            queryParameters.Add($"colors={colors}");
        if (limit > 0)
            queryParameters.Add($"limit={limit}");
        queryParameters.Add($"new={@new.ToString().ToLower()}");
        if (offset > 0)
            queryParameters.Add($"offset={offset}");
        if (placements != null && placements.Count > 0)
            queryParameters.Add($"placements={string.Join(",", placements)}");
        if (!string.IsNullOrEmpty(selling_region_name))
            queryParameters.Add($"selling_region_name={selling_region_name}");
        if (!string.IsNullOrEmpty(sort_direction))
            queryParameters.Add($"sort_direction={sort_direction}");
        if (!string.IsNullOrEmpty(sort_type))
            queryParameters.Add($"sort_type={sort_type}");
        if (techniques != null && techniques.Count > 0)
            queryParameters.Add($"techniques={string.Join(",", techniques)}");

        if (queryParameters.Count > 0)
        {
            requestUrl += "?" + string.Join("&", queryParameters);
        }

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

    [HttpGet("GetById")]
    public async Task<IActionResult> GetPricesById(int id)
    {
        var requestUrl = "https://api.printful.com/v2/catalog-variants/{id}/prices";

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

    [HttpGet("{id}/images")]
    public async Task<IActionResult> GetImagesById(int id)
    {
        var requestUrl = "https://api.printful.com/v2/catalog-variants/{id}/images";

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

    [HttpGet("{id}/availability")]
    public async Task<IActionResult> GetAvailabilityById(int id)
    {
        var requestUrl = "https://api.printful.com/v2/catalog-variants/{id}/availability";

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