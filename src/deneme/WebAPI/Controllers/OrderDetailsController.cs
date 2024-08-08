using Application.Features.OrderDetails.Commands.Create;
using Application.Features.OrderDetails.Commands.Delete;
using Application.Features.OrderDetails.Commands.Update;
using Application.Features.OrderDetails.Queries.GetById;
using Application.Features.OrderDetails.Queries.GetList;
using NArchitecture.Core.Application.Requests;
using NArchitecture.Core.Application.Responses;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class OrderDetailsController : BaseController
{
    [HttpPost]
    public async Task<ActionResult<CreatedOrderDetailResponse>> Add([FromBody] CreateOrderDetailCommand command)
    {
        CreatedOrderDetailResponse response = await Mediator.Send(command);

        return CreatedAtAction(nameof(GetById), new { response.Id }, response);
    }

    [HttpPut]
    public async Task<ActionResult<UpdatedOrderDetailResponse>> Update([FromBody] UpdateOrderDetailCommand command)
    {
        UpdatedOrderDetailResponse response = await Mediator.Send(command);

        return Ok(response);
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult<DeletedOrderDetailResponse>> Delete([FromRoute] Guid id)
    {
        DeleteOrderDetailCommand command = new() { Id = id };

        DeletedOrderDetailResponse response = await Mediator.Send(command);

        return Ok(response);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<GetByIdOrderDetailResponse>> GetById([FromRoute] Guid id)
    {
        GetByIdOrderDetailQuery query = new() { Id = id };

        GetByIdOrderDetailResponse response = await Mediator.Send(query);

        return Ok(response);
    }

    [HttpGet]
    public async Task<ActionResult<GetListOrderDetailQuery>> GetList([FromQuery] PageRequest pageRequest)
    {
        GetListOrderDetailQuery query = new() { PageRequest = pageRequest };

        GetListResponse<GetListOrderDetailListItemDto> response = await Mediator.Send(query);

        return Ok(response);
    }
}