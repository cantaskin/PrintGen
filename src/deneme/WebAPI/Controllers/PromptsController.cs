using Application.Features.Prompts.Commands.Create;
using Application.Features.Prompts.Commands.Delete;
using Application.Features.Prompts.Queries.GetById;
using Application.Features.Prompts.Queries.GetList;
using NArchitecture.Core.Application.Requests;
using NArchitecture.Core.Application.Responses;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[Route("api/prompt")]
[ApiController]
public class PromptsController : BaseController
{
    [HttpPost]
    public async Task<ActionResult<CreatedPromptResponse>> Add([FromBody] CreatePromptCommand command)
    {
        CreatedPromptResponse response = await Mediator.Send(command);

        return CreatedAtAction(nameof(GetById), new { response.Id }, response);
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult<DeletedPromptResponse>> Delete([FromRoute] Guid id)
    {
        DeletePromptCommand command = new() { Id = id };

        DeletedPromptResponse response = await Mediator.Send(command);

        return Ok(response);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<GetByIdPromptResponse>> GetById([FromRoute] Guid id)
    {
        GetByIdPromptQuery query = new() { Id = id };

        GetByIdPromptResponse response = await Mediator.Send(query);

        return Ok(response);
    }

    [HttpGet]
    public async Task<ActionResult<GetListPromptQuery>> GetList([FromQuery] PageRequest pageRequest)
    {
        GetListPromptQuery query = new() { PageRequest = pageRequest };

        GetListResponse<GetListPromptListItemDto> response = await Mediator.Send(query);

        return Ok(response);
    }
}