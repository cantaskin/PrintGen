using Application.Features.Placements.Commands.Create;
using Application.Features.Placements.Commands.Delete;
using Application.Features.Placements.Commands.Update;
using Application.Features.Placements.Queries.GetById;
using Application.Features.Placements.Queries.GetList;
using NArchitecture.Core.Application.Requests;
using NArchitecture.Core.Application.Responses;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class PlacementsController : BaseController
{
    [HttpPost]
    public async Task<ActionResult<CreatedPlacementResponse>> Add([FromBody] CreatePlacementCommand command)
    {
        CreatedPlacementResponse response = await Mediator.Send(command);

        return CreatedAtAction(nameof(GetById), new { response.Id }, response);
    }

    [HttpPut]
    public async Task<ActionResult<UpdatedPlacementResponse>> Update([FromBody] UpdatePlacementCommand command)
    {
        UpdatedPlacementResponse response = await Mediator.Send(command);

        return Ok(response);
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult<DeletedPlacementResponse>> Delete([FromRoute] Guid id)
    {
        DeletePlacementCommand command = new() { Id = id };

        DeletedPlacementResponse response = await Mediator.Send(command);

        return Ok(response);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<GetByIdPlacementResponse>> GetById([FromRoute] Guid id)
    {
        GetByIdPlacementQuery query = new() { Id = id };

        GetByIdPlacementResponse response = await Mediator.Send(query);

        return Ok(response);
    }

    [HttpGet]
    public async Task<ActionResult<GetListPlacementQuery>> GetList([FromQuery] PageRequest pageRequest)
    {
        GetListPlacementQuery query = new() { PageRequest = pageRequest };

        GetListResponse<GetListPlacementListItemDto> response = await Mediator.Send(query);

        return Ok(response);
    }
}