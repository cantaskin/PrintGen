using Application.Features.ProductImages.Commands.Create;
using Application.Features.ProductImages.Commands.Delete;
using Application.Features.ProductImages.Commands.Update;
using Application.Features.ProductImages.Queries.GetById;
using Application.Features.ProductImages.Queries.GetList;
using NArchitecture.Core.Application.Requests;
using NArchitecture.Core.Application.Responses;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ProductImagesController : BaseController
{
    [HttpPost]
    public async Task<ActionResult<CreatedProductImageResponse>> Add([FromBody] CreateProductImageCommand command)
    {
        CreatedProductImageResponse response = await Mediator.Send(command);

        return CreatedAtAction(nameof(GetById), new { response.Id }, response);
    }

    [HttpPut]
    public async Task<ActionResult<UpdatedProductImageResponse>> Update([FromBody] UpdateProductImageCommand command)
    {
        UpdatedProductImageResponse response = await Mediator.Send(command);

        return Ok(response);
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult<DeletedProductImageResponse>> Delete([FromRoute] Guid id)
    {
        DeleteProductImageCommand command = new() { Id = id };

        DeletedProductImageResponse response = await Mediator.Send(command);

        return Ok(response);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<GetByIdProductImageResponse>> GetById([FromRoute] Guid id)
    {
        GetByIdProductImageQuery query = new() { Id = id };

        GetByIdProductImageResponse response = await Mediator.Send(query);

        return Ok(response);
    }

    [HttpGet]
    public async Task<ActionResult<GetListProductImageQuery>> GetList([FromQuery] PageRequest pageRequest)
    {
        GetListProductImageQuery query = new() { PageRequest = pageRequest };

        GetListResponse<GetListProductImageListItemDto> response = await Mediator.Send(query);

        return Ok(response);
    }
}