using Application.Features.PromptCategories.Commands.Create;
using Application.Features.PromptCategories.Commands.Delete;
using Application.Features.PromptCategories.Commands.Update;
using Application.Features.PromptCategories.Queries.GetById;
using Application.Features.PromptCategories.Queries.GetList;
using NArchitecture.Core.Application.Requests;
using NArchitecture.Core.Application.Responses;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class PromptCategoriesController : BaseController
{
    [HttpPost]
    public async Task<ActionResult<CreatedPromptCategoryResponse>> Add([FromBody] CreatePromptCategoryCommand command)
    {
        CreatedPromptCategoryResponse response = await Mediator.Send(command);

        return CreatedAtAction(nameof(GetById), new { response.Id }, response);
    }

    [HttpPut]
    public async Task<ActionResult<UpdatedPromptCategoryResponse>> Update([FromBody] UpdatePromptCategoryCommand command)
    {
        UpdatedPromptCategoryResponse response = await Mediator.Send(command);

        return Ok(response);
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult<DeletedPromptCategoryResponse>> Delete([FromRoute] Guid id)
    {
        DeletePromptCategoryCommand command = new() { Id = id };

        DeletedPromptCategoryResponse response = await Mediator.Send(command);

        return Ok(response);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<GetByIdPromptCategoryResponse>> GetById([FromRoute] Guid id)
    {
        GetByIdPromptCategoryQuery query = new() { Id = id };

        GetByIdPromptCategoryResponse response = await Mediator.Send(query);

        return Ok(response);
    }

    [HttpGet]
    public async Task<ActionResult<GetListPromptCategoryQuery>> GetList([FromQuery] PageRequest pageRequest)
    {
        GetListPromptCategoryQuery query = new() { PageRequest = pageRequest };

        GetListResponse<GetListPromptCategoryListItemDto> response = await Mediator.Send(query);

        return Ok(response);
    }
}