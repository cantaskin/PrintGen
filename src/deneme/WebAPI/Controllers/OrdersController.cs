using Application.Features.Orders.Commands.Create;
using Application.Features.Orders.Commands.Delete;
using Application.Features.Orders.Commands.Update;
using Application.Features.Orders.Queries.GetById;
using Application.Features.Orders.Queries.GetList;
using NArchitecture.Core.Application.Requests;
using NArchitecture.Core.Application.Responses;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class OrdersController : BaseController
{
    [HttpPost]
    public async Task<ActionResult<CreatedOrderResponse>> Add([FromBody] CreateOrderCommand command)
    {
        CreatedOrderResponse response = await Mediator.Send(command);

        return CreatedAtAction(nameof(GetById), new { response.Id }, response);
    }

    [HttpPut]
    public async Task<ActionResult<UpdatedOrderResponse>> Update([FromBody] UpdateOrderCommand command)
    {
        UpdatedOrderResponse response = await Mediator.Send(command);

        return Ok(response);
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult<DeletedOrderResponse>> Delete([FromRoute] Guid id)
    {
        DeleteOrderCommand command = new() { Id = id };

        DeletedOrderResponse response = await Mediator.Send(command);

        return Ok(response);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<GetByIdOrderResponse>> GetById([FromRoute] Guid id)
    {
        GetByIdOrderQuery query = new() { Id = id };

        GetByIdOrderResponse response = await Mediator.Send(query);

        return Ok(response);
    }

    [HttpGet]
    public async Task<ActionResult<GetListOrderQuery>> GetList([FromQuery] PageRequest pageRequest)
    {
        GetListOrderQuery query = new() { PageRequest = pageRequest };

        GetListResponse<GetListOrderListItemDto> response = await Mediator.Send(query);

        return Ok(response);
    }
}