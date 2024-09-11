using Application.Features.OrderItems.Commands.Create;
using Application.Features.OrderItems.Commands.Delete;
using Application.Features.OrderItems.Commands.Update;
using Application.Features.OrderItems.Queries.GetById;
using Application.Features.OrderItems.Queries.GetList;
using NArchitecture.Core.Application.Requests;
using NArchitecture.Core.Application.Responses;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[Route("api/orderitem")]
[ApiController]
public class OrderItemsController : BaseController
{
    [HttpPost]
    public async Task<ActionResult<CreatedOrderItemResponse>> Add([FromBody] CreateOrderItemCommand command)
    {
        CreatedOrderItemResponse response = await Mediator.Send(command);

        return CreatedAtAction(nameof(GetById), new { response.Id }, response);
    }

    [HttpPut]
    public async Task<ActionResult<UpdatedOrderItemResponse>> Update([FromBody] UpdateOrderItemCommand command)
    {
        UpdatedOrderItemResponse response = await Mediator.Send(command);

        return Ok(response);
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult<DeletedOrderItemResponse>> Delete([FromRoute] Guid id)
    {
        DeleteOrderItemCommand command = new() { Id = id };

        DeletedOrderItemResponse response = await Mediator.Send(command);

        return Ok(response);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<GetByIdOrderItemResponse>> GetById([FromRoute] Guid id)
    {
        GetByIdOrderItemQuery query = new() { Id = id };

        GetByIdOrderItemResponse response = await Mediator.Send(query);

        return Ok(response);
    }

    [HttpGet]
    public async Task<ActionResult<GetListOrderItemQuery>> GetList([FromQuery] PageRequest pageRequest)
    {
        GetListOrderItemQuery query = new() { PageRequest = pageRequest };

        GetListResponse<GetListOrderItemListItemDto> response = await Mediator.Send(query);

        return Ok(response);
    }
}