using Application.Features.CustomizedImages.Commands.Create;
using Application.Features.CustomizedImages.Commands.Delete;
using Application.Features.CustomizedImages.Commands.Update;
using Application.Features.CustomizedImages.Queries.GetById;
using Application.Features.CustomizedImages.Queries.GetList;
using NArchitecture.Core.Application.Requests;
using NArchitecture.Core.Application.Responses;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CustomizedImagesController : BaseController
{
    [HttpPost]
    public async Task<ActionResult<CreatedCustomizedImageResponse>> Add([FromBody] CreateCustomizedImageCommand command)
    {
        CreatedCustomizedImageResponse response = await Mediator.Send(command);

        return CreatedAtAction(nameof(GetById), new { response.Id }, response);
    }

    [HttpPut]
    public async Task<ActionResult<UpdatedCustomizedImageResponse>> Update([FromBody] UpdateCustomizedImageCommand command)
    {
        UpdatedCustomizedImageResponse response = await Mediator.Send(command);

        return Ok(response);
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult<DeletedCustomizedImageResponse>> Delete([FromRoute] Guid id)
    {
        DeleteCustomizedImageCommand command = new() { Id = id };

        DeletedCustomizedImageResponse response = await Mediator.Send(command);

        return Ok(response);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<GetByIdCustomizedImageResponse>> GetById([FromRoute] Guid id)
    {
        GetByIdCustomizedImageQuery query = new() { Id = id };

        GetByIdCustomizedImageResponse response = await Mediator.Send(query);

        return Ok(response);
    }

    [HttpGet]
    public async Task<ActionResult<GetListCustomizedImageQuery>> GetList([FromQuery] PageRequest pageRequest)
    {
        GetListCustomizedImageQuery query = new() { PageRequest = pageRequest };

        GetListResponse<GetListCustomizedImageListItemDto> response = await Mediator.Send(query);

        return Ok(response);
    }
}