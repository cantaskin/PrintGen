using Application.Features.PrintAreas.Commands.Create;
using Application.Features.PrintAreas.Commands.Delete;
using Application.Features.PrintAreas.Commands.Update;
using Application.Features.PrintAreas.Queries.GetById;
using Application.Features.PrintAreas.Queries.GetList;
using NArchitecture.Core.Application.Requests;
using NArchitecture.Core.Application.Responses;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class PrintAreasController : BaseController
{
    [HttpPost]
    public async Task<ActionResult<CreatedPrintAreaResponse>> Add([FromBody] CreatePrintAreaCommand command)
    {
        CreatedPrintAreaResponse response = await Mediator.Send(command);

        return CreatedAtAction(nameof(GetById), new { response.Id }, response);
    }

    [HttpPut]
    public async Task<ActionResult<UpdatedPrintAreaResponse>> Update([FromBody] UpdatePrintAreaCommand command)
    {
        UpdatedPrintAreaResponse response = await Mediator.Send(command);

        return Ok(response);
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult<DeletedPrintAreaResponse>> Delete([FromRoute] Guid id)
    {
        DeletePrintAreaCommand command = new() { Id = id };

        DeletedPrintAreaResponse response = await Mediator.Send(command);

        return Ok(response);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<GetByIdPrintAreaResponse>> GetById([FromRoute] Guid id)
    {
        GetByIdPrintAreaQuery query = new() { Id = id };

        GetByIdPrintAreaResponse response = await Mediator.Send(query);

        return Ok(response);
    }

    [HttpGet]
    public async Task<ActionResult<GetListPrintAreaQuery>> GetList([FromQuery] PageRequest pageRequest)
    {
        GetListPrintAreaQuery query = new() { PageRequest = pageRequest };

        GetListResponse<GetListPrintAreaListItemDto> response = await Mediator.Send(query);

        return Ok(response);
    }
}