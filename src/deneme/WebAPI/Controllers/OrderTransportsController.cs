using Application.Features.OrderTransports.Commands.Create;
using Application.Features.OrderTransports.Commands.Delete;
using Application.Features.OrderTransports.Commands.Update;
using Application.Features.OrderTransports.Queries.GetById;
using Application.Features.OrderTransports.Queries.GetList;
using NArchitecture.Core.Application.Requests;
using NArchitecture.Core.Application.Responses;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class OrderTransportsController : BaseController
{
    [HttpPost]
    public async Task<ActionResult<CreatedOrderTransportResponse>> Add([FromBody] CreateOrderTransportCommand command)
    {
        CreatedOrderTransportResponse response = await Mediator.Send(command);

        return CreatedAtAction(nameof(GetById), new { response.Id }, response);
    }

    [HttpPut]
    public async Task<ActionResult<UpdatedOrderTransportResponse>> Update([FromBody] UpdateOrderTransportCommand command)
    {
        UpdatedOrderTransportResponse response = await Mediator.Send(command);

        return Ok(response);
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult<DeletedOrderTransportResponse>> Delete([FromRoute] Guid id)
    {
        DeleteOrderTransportCommand command = new() { Id = id };

        DeletedOrderTransportResponse response = await Mediator.Send(command);

        return Ok(response);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<GetByIdOrderTransportResponse>> GetById([FromRoute] Guid id)
    {
        GetByIdOrderTransportQuery query = new() { Id = id };

        GetByIdOrderTransportResponse response = await Mediator.Send(query);

        return Ok(response);
    }

    [HttpGet]
    public async Task<ActionResult<GetListOrderTransportQuery>> GetList([FromQuery] PageRequest pageRequest)
    {
        GetListOrderTransportQuery query = new() { PageRequest = pageRequest };

        GetListResponse<GetListOrderTransportListItemDto> response = await Mediator.Send(query);

        return Ok(response);
    }
}