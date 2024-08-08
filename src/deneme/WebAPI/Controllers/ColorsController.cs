using Application.Features.Colors.Commands.Create;
using Application.Features.Colors.Commands.Delete;
using Application.Features.Colors.Commands.Update;
using Application.Features.Colors.Queries.GetById;
using Application.Features.Colors.Queries.GetList;
using NArchitecture.Core.Application.Requests;
using NArchitecture.Core.Application.Responses;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ColorsController : BaseController
{
    [HttpPost("Add")]
    public async Task<ActionResult<CreatedColorResponse>> Add([FromBody] CreateColorCommand command)
    {
        CreatedColorResponse response = await Mediator.Send(command);

        return CreatedAtAction(nameof(GetById), new { response.Id }, response);
    }

    [HttpPut("Update")]
    public async Task<ActionResult<UpdatedColorResponse>> Update([FromBody] UpdateColorCommand command)
    {
        UpdatedColorResponse response = await Mediator.Send(command);

        return Ok(response);
    }

    [HttpDelete("Delete")]
    public async Task<ActionResult<DeletedColorResponse>> Delete(Guid id)
    {
        DeleteColorCommand command = new() { Id = id };

        DeletedColorResponse response = await Mediator.Send(command);

        return Ok(response);
    }

    [HttpGet("GetById")]
    public async Task<ActionResult<GetByIdColorResponse>> GetById(Guid id)
    {
        GetByIdColorQuery query = new() { Id = id };

        GetByIdColorResponse response = await Mediator.Send(query);

        return Ok(response);
    }

    [HttpGet("GetAll")]
    public async Task<ActionResult<GetListColorQuery>> GetList([FromQuery] PageRequest pageRequest)
    {
        GetListColorQuery query = new() { PageRequest = pageRequest };

        GetListResponse<GetListColorListItemDto> response = await Mediator.Send(query);

        return Ok(response);
    }
}