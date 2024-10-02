using Domain.DTO;
using Infrastructure.Adapters.PrintfulService;
using Microsoft.AspNetCore.Mvc;
using Org.BouncyCastle.Crypto;

namespace WebAPI.Controllers;


[Route("api/shippingrate")]
public class ShippingRateController : BaseController
{
    private readonly PrintfulServiceAdapter _printfulServiceAdapter;
    public ShippingRateController (PrintfulServiceAdapter printfulServiceAdapter)
    {
        _printfulServiceAdapter = printfulServiceAdapter;
    }

    [HttpPost]
    public async Task<ActionResult> Add([FromBody] ShippingRateDto shippingRateDto)
    {
       var response =  await _printfulServiceAdapter.CreateShippingRateAsync(shippingRateDto);
       return Ok(response);
    }
}
