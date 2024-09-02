using Application.Features.Gifts.Commands.Create;
using Application.Features.Gifts.Commands.Delete;
using Application.Features.Gifts.Commands.Update;
using Application.Features.Gifts.Queries.GetById;
using Application.Features.Gifts.Queries.GetList;
using NArchitecture.Core.Application.Requests;
using NArchitecture.Core.Application.Responses;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class GiftsController : BaseController
{
    [HttpPost]
    public async Task<ActionResult<CreatedGiftResponse>> Add([FromBody] CreateGiftCommand command)
    {
        CreatedGiftResponse response = await Mediator.Send(command);

        return CreatedAtAction(nameof(GetById), new { response.Id }, response);
    }

    [HttpPut]
    public async Task<ActionResult<UpdatedGiftResponse>> Update([FromBody] UpdateGiftCommand command)
    {
        UpdatedGiftResponse response = await Mediator.Send(command);

        return Ok(response);
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult<DeletedGiftResponse>> Delete([FromRoute] Guid id)
    {
        DeleteGiftCommand command = new() { Id = id };

        DeletedGiftResponse response = await Mediator.Send(command);

        return Ok(response);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<GetByIdGiftResponse>> GetById([FromRoute] Guid id)
    {
        GetByIdGiftQuery query = new() { Id = id };

        GetByIdGiftResponse response = await Mediator.Send(query);

        return Ok(response);
    }

    [HttpGet]
    public async Task<ActionResult<GetListGiftQuery>> GetList([FromQuery] PageRequest pageRequest)
    {
        GetListGiftQuery query = new() { PageRequest = pageRequest };

        GetListResponse<GetListGiftListItemDto> response = await Mediator.Send(query);

        return Ok(response);
    }
}