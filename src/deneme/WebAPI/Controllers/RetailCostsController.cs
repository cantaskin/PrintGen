using Application.Features.RetailCosts.Commands.Create;
using Application.Features.RetailCosts.Commands.Delete;
using Application.Features.RetailCosts.Commands.Update;
using Application.Features.RetailCosts.Queries.GetById;
using Application.Features.RetailCosts.Queries.GetList;
using NArchitecture.Core.Application.Requests;
using NArchitecture.Core.Application.Responses;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class RetailCostsController : BaseController
{
    [HttpPost]
    public async Task<ActionResult<CreatedRetailCostResponse>> Add([FromBody] CreateRetailCostCommand command)
    {
        CreatedRetailCostResponse response = await Mediator.Send(command);

        return CreatedAtAction(nameof(GetById), new { id = response.Id }, response);

    }

    [HttpPut]
    public async Task<ActionResult<UpdatedRetailCostResponse>> Update([FromBody] UpdateRetailCostCommand command)
    {
        UpdatedRetailCostResponse response = await Mediator.Send(command);

        return Ok(response);
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult<DeletedRetailCostResponse>> Delete([FromRoute] Guid id)
    {
        DeleteRetailCostCommand command = new() { Id = id };

        DeletedRetailCostResponse response = await Mediator.Send(command);

        return Ok(response);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<GetByIdRetailCostResponse>> GetById([FromRoute] Guid id)
    {
        GetByIdRetailCostQuery query = new() { Id = id };

        GetByIdRetailCostResponse response = await Mediator.Send(query);

        return Ok(response);
    }

    [HttpGet]
    public async Task<ActionResult<GetListRetailCostQuery>> GetList([FromQuery] PageRequest pageRequest)
    {
        GetListRetailCostQuery query = new() { PageRequest = pageRequest };

        GetListResponse<GetListRetailCostListItemDto> response = await Mediator.Send(query);

        return Ok(response);
    }
}