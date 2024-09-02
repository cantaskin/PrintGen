using Application.Features.Layers.Commands.Create;
using Application.Features.Layers.Commands.Delete;
using Application.Features.Layers.Commands.Update;
using Application.Features.Layers.Queries.GetById;
using Application.Features.Layers.Queries.GetList;
using NArchitecture.Core.Application.Requests;
using NArchitecture.Core.Application.Responses;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class LayersController : BaseController
{
    [HttpPost]
    public async Task<ActionResult<CreatedLayerResponse>> Add([FromBody] CreateLayerCommand command)
    {
        CreatedLayerResponse response = await Mediator.Send(command);

        return CreatedAtAction(nameof(GetById), new { response.Id }, response);
    }

    [HttpPut]
    public async Task<ActionResult<UpdatedLayerResponse>> Update([FromBody] UpdateLayerCommand command)
    {
        UpdatedLayerResponse response = await Mediator.Send(command);

        return Ok(response);
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult<DeletedLayerResponse>> Delete([FromRoute] Guid id)
    {
        DeleteLayerCommand command = new() { Id = id };

        DeletedLayerResponse response = await Mediator.Send(command);

        return Ok(response);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<GetByIdLayerResponse>> GetById([FromRoute] Guid id)
    {
        GetByIdLayerQuery query = new() { Id = id };

        GetByIdLayerResponse response = await Mediator.Send(query);

        return Ok(response);
    }

    [HttpGet]
    public async Task<ActionResult<GetListLayerQuery>> GetList([FromQuery] PageRequest pageRequest)
    {
        GetListLayerQuery query = new() { PageRequest = pageRequest };

        GetListResponse<GetListLayerListItemDto> response = await Mediator.Send(query);

        return Ok(response);
    }
}