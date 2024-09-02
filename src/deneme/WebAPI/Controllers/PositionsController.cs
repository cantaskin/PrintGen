using Application.Features.Positions.Commands.Create;
using Application.Features.Positions.Commands.Delete;
using Application.Features.Positions.Commands.Update;
using Application.Features.Positions.Queries.GetById;
using Application.Features.Positions.Queries.GetList;
using NArchitecture.Core.Application.Requests;
using NArchitecture.Core.Application.Responses;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class PositionsController : BaseController
{
    [HttpPost]
    public async Task<ActionResult<CreatedPositionResponse>> Add([FromBody] CreatePositionCommand command)
    {
        CreatedPositionResponse response = await Mediator.Send(command);

        return CreatedAtAction(nameof(GetById), new { response.Id }, response);
    }

    [HttpPut]
    public async Task<ActionResult<UpdatedPositionResponse>> Update([FromBody] UpdatePositionCommand command)
    {
        UpdatedPositionResponse response = await Mediator.Send(command);

        return Ok(response);
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult<DeletedPositionResponse>> Delete([FromRoute] Guid id)
    {
        DeletePositionCommand command = new() { Id = id };

        DeletedPositionResponse response = await Mediator.Send(command);

        return Ok(response);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<GetByIdPositionResponse>> GetById([FromRoute] Guid id)
    {
        GetByIdPositionQuery query = new() { Id = id };

        GetByIdPositionResponse response = await Mediator.Send(query);

        return Ok(response);
    }

    [HttpGet]
    public async Task<ActionResult<GetListPositionQuery>> GetList([FromQuery] PageRequest pageRequest)
    {
        GetListPositionQuery query = new() { PageRequest = pageRequest };

        GetListResponse<GetListPositionListItemDto> response = await Mediator.Send(query);

        return Ok(response);
    }
}