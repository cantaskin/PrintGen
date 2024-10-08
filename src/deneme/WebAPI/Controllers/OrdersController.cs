using Application.Features.Orders.Commands.Create;
using Application.Features.Orders.Commands.Delete;
using Application.Features.Orders.Commands.Update;
using Application.Features.Orders.Queries.GetById;
using Application.Features.Orders.Queries.GetList;
using Infrastructure.Adapters.PrintfulService;
using NArchitecture.Core.Application.Requests;
using NArchitecture.Core.Application.Responses;
using Microsoft.AspNetCore.Mvc;
using Application.Features.Orders.Queries.GetListbyUserId;

namespace WebAPI.Controllers;

[Route("api/order")]
[ApiController]
public class OrdersController : BaseController
{
    private readonly PrintfulServiceAdapter printfulServiceAdapter;
    
    public OrdersController(PrintfulServiceAdapter _printfulServiceAdapter)
    {
        printfulServiceAdapter = _printfulServiceAdapter;
        
    }

    [HttpPost]
    public async Task<ActionResult<CreatedOrderResponse>> Add([FromBody] CreateOrderCommand command)
    {
        CreatedOrderResponse response = await Mediator.Send(command);

        return CreatedAtAction(nameof(GetById), new { response.Id }, response);
    }


    // [HttpPut("{id}")]
    // public  async Task<ActionResult> Create([FromRoute] Guid id)
    // {
    //     await printfulServiceAdapter.CreateOrderAsync(id);
    //     return Ok();
    // }


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

        GetListResponse<GetListdOrderListItemDto> response = await Mediator.Send(query);

        return Ok(response);
    }

    [HttpGet("{id}/List")]
    public async Task<ActionResult<GetListbyUserIdOrderQuery>> GetList([FromQuery] PageRequest pageRequest, [FromRoute] Guid id)
    {
        GetListbyUserIdOrderQuery query = new() { PageRequest = pageRequest , UserId = id};

        GetListResponse<GetListbyUserIdOrderListItemDto> response = await Mediator.Send(query);

        return Ok(response);
    }
}