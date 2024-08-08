using Application.Features.PrintAreaNames.Commands.Create;
using Application.Features.PrintAreaNames.Commands.Delete;
using Application.Features.PrintAreaNames.Commands.Update;
using Application.Features.PrintAreaNames.Queries.GetById;
using Application.Features.PrintAreaNames.Queries.GetList;
using NArchitecture.Core.Application.Requests;
using NArchitecture.Core.Application.Responses;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class PrintAreaNamesController : BaseController
{
    [HttpPost]
    public async Task<ActionResult<CreatedPrintAreaNameResponse>> Add([FromBody] CreatePrintAreaNameCommand command)
    {
        CreatedPrintAreaNameResponse response = await Mediator.Send(command);

        return CreatedAtAction(nameof(GetById), new { response.Id }, response);
    }

    [HttpPut]
    public async Task<ActionResult<UpdatedPrintAreaNameResponse>> Update([FromBody] UpdatePrintAreaNameCommand command)
    {
        UpdatedPrintAreaNameResponse response = await Mediator.Send(command);

        return Ok(response);
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult<DeletedPrintAreaNameResponse>> Delete([FromRoute] Guid id)
    {
        DeletePrintAreaNameCommand command = new() { Id = id };

        DeletedPrintAreaNameResponse response = await Mediator.Send(command);

        return Ok(response);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<GetByIdPrintAreaNameResponse>> GetById([FromRoute] Guid id)
    {
        GetByIdPrintAreaNameQuery query = new() { Id = id };

        GetByIdPrintAreaNameResponse response = await Mediator.Send(query);

        return Ok(response);
    }

    [HttpGet]
    public async Task<ActionResult<GetListPrintAreaNameQuery>> GetList([FromQuery] PageRequest pageRequest)
    {
        GetListPrintAreaNameQuery query = new() { PageRequest = pageRequest };

        GetListResponse<GetListPrintAreaNameListItemDto> response = await Mediator.Send(query);

        return Ok(response);
    }
}