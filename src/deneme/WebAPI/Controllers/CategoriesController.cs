using Application.Features.Categories.Commands.Create;
using Application.Features.Categories.Commands.Delete;
using Application.Features.Categories.Commands.Update;
using Application.Features.Categories.Queries.GetById;
using Application.Features.Categories.Queries.GetList;
using NArchitecture.Core.Application.Requests;
using NArchitecture.Core.Application.Responses;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CategoriesController : BaseController
{
    [HttpPost("Add")]
    public async Task<ActionResult<CreatedCategoryResponse>> Add([FromBody] CreateCategoryCommand command)
    {
        CreatedCategoryResponse response = await Mediator.Send(command);

        return CreatedAtAction(nameof(GetById), new { response.Id }, response);
    }

    [HttpPut("Update")]
    public async Task<ActionResult<UpdatedCategoryResponse>> Update([FromBody] UpdateCategoryCommand command)
    {
        UpdatedCategoryResponse response = await Mediator.Send(command);

        return Ok(response);
    }

    [HttpDelete("Delete")]
    public async Task<ActionResult<DeletedCategoryResponse>> Delete(Guid id)
    {
        DeleteCategoryCommand command = new() { Id = id };

        DeletedCategoryResponse response = await Mediator.Send(command);

        return Ok(response);
    }

    [HttpGet("GetById")]
    public async Task<ActionResult<GetByIdCategoryResponse>> GetById(Guid id)
    {
        GetByIdCategoryQuery query = new() { Id = id };

        GetByIdCategoryResponse response = await Mediator.Send(query);

        return Ok(response);
    }

    [HttpGet("GetAll")]
    public async Task<ActionResult<GetListCategoryQuery>> GetList([FromQuery] PageRequest pageRequest)
    {
        GetListCategoryQuery query = new() { PageRequest = pageRequest };

        GetListResponse<GetListCategoryListItemDto> response = await Mediator.Send(query);

        return Ok(response);
    }
}