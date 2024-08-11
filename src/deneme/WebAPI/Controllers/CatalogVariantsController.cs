using Infrastructure.Adapters.PrintfulService;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http.Headers;
using WebAPI.Controllers;

namespace WebAPI;

[Route("Deneme/[controller]")]
[ApiController]
public class CatalogVariantsController : BaseController
{
    private readonly PrintfulServiceAdapter _printfulServiceAdapter;

    public CatalogVariantsController(PrintfulServiceAdapter printfulServiceAdapte)
    {
        _printfulServiceAdapter = printfulServiceAdapte;
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var requestUrl = $"https://api.printful.com/v2/catalog-variants/{id}";

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




    [HttpGet("{id}/prices")]
    public async Task<IActionResult> GetPricesById(int id, string? sellingRegionName, string? currency)
    {
        var requestUrl = $"https://api.printful.com/v2/catalog-variants/{id}/prices";

        var queryParameters = new List<string>();

        if (!string.IsNullOrEmpty(sellingRegionName))
        {
            queryParameters.Add($"selling_region_name={sellingRegionName}");
        }

        if (!string.IsNullOrEmpty(currency))
        {
            queryParameters.Add($"currency={currency}");
        }

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

    [HttpGet("{id}/images")]
    public async Task<IActionResult> GetImagesById(int id, List<int>? mockupStyleIds, string? placement)
    {
        var requestUrl = $"https://api.printful.com/v2/catalog-variants/{id}/images";

        var queryParameters = new List<string>();

        if (mockupStyleIds != null && mockupStyleIds.Count > 0)
        {
            queryParameters.Add($"mockup_style_ids={string.Join(",", mockupStyleIds)}");
        }

        if (!string.IsNullOrEmpty(placement))
        {
            queryParameters.Add($"placement={placement}");
        }

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

    [HttpGet("{id}/availability")]
    public async Task<IActionResult> GetAvailabilityById(int id, List<string>? techniques, string? sellingRegionName)
    {
        var requestUrl = $"https://api.printful.com/v2/catalog-variants/{id}/availability";

        var queryParameters = new List<string>();

        if (techniques != null && techniques.Count > 0)
        {
            queryParameters.Add($"techniques={string.Join(",", techniques)}");
        }

        if (!string.IsNullOrEmpty(sellingRegionName))
        {
            queryParameters.Add($"selling_region_name={sellingRegionName}");
        }

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
}