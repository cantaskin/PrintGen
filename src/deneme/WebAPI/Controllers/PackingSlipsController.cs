using Application.Features.PackingSlips.Commands.Create;
using Application.Features.PackingSlips.Commands.Delete;
using Application.Features.PackingSlips.Commands.Update;
using Application.Features.PackingSlips.Queries.GetById;
using Application.Features.PackingSlips.Queries.GetList;
using NArchitecture.Core.Application.Requests;
using NArchitecture.Core.Application.Responses;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class PackingSlipsController : BaseController
{
    [HttpPost]
    public async Task<ActionResult<CreatedPackingSlipResponse>> Add([FromBody] CreatePackingSlipCommand command)
    {
        CreatedPackingSlipResponse response = await Mediator.Send(command);

        return CreatedAtAction(nameof(GetById), new { response.Id }, response);
    }

    [HttpPut]
    public async Task<ActionResult<UpdatedPackingSlipResponse>> Update([FromBody] UpdatePackingSlipCommand command)
    {
        UpdatedPackingSlipResponse response = await Mediator.Send(command);

        return Ok(response);
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult<DeletedPackingSlipResponse>> Delete([FromRoute] Guid id)
    {
        DeletePackingSlipCommand command = new() { Id = id };

        DeletedPackingSlipResponse response = await Mediator.Send(command);

        return Ok(response);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<GetByIdPackingSlipResponse>> GetById([FromRoute] Guid id)
    {
        GetByIdPackingSlipQuery query = new() { Id = id };

        GetByIdPackingSlipResponse response = await Mediator.Send(query);

        return Ok(response);
    }

    [HttpGet]
    public async Task<ActionResult<GetListPackingSlipQuery>> GetList([FromQuery] PageRequest pageRequest)
    {
        GetListPackingSlipQuery query = new() { PageRequest = pageRequest };

        GetListResponse<GetListPackingSlipListItemDto> response = await Mediator.Send(query);

        return Ok(response);
    }
}