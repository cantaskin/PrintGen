using Application.Features.CustomizedProducts.Commands.Create;
using Application.Features.CustomizedProducts.Commands.Delete;
using Application.Features.CustomizedProducts.Commands.Update;
using Application.Features.CustomizedProducts.Queries.GetById;
using Application.Features.CustomizedProducts.Queries.GetList;
using NArchitecture.Core.Application.Requests;
using NArchitecture.Core.Application.Responses;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CustomizedProductsController : BaseController
{
    [HttpPost]
    public async Task<ActionResult<CreatedCustomizedProductResponse>> Add([FromBody] CreateCustomizedProductCommand command)
    {
        CreatedCustomizedProductResponse response = await Mediator.Send(command);

        return CreatedAtAction(nameof(GetById), new { response.Id }, response);
    }

    [HttpPut]
    public async Task<ActionResult<UpdatedCustomizedProductResponse>> Update([FromBody] UpdateCustomizedProductCommand command)
    {
        UpdatedCustomizedProductResponse response = await Mediator.Send(command);

        return Ok(response);
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult<DeletedCustomizedProductResponse>> Delete([FromRoute] Guid id)
    {
        DeleteCustomizedProductCommand command = new() { Id = id };

        DeletedCustomizedProductResponse response = await Mediator.Send(command);

        return Ok(response);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<GetByIdCustomizedProductResponse>> GetById([FromRoute] Guid id)
    {
        GetByIdCustomizedProductQuery query = new() { Id = id };

        GetByIdCustomizedProductResponse response = await Mediator.Send(query);

        return Ok(response);
    }

    [HttpGet]
    public async Task<ActionResult<GetListCustomizedProductQuery>> GetList([FromQuery] PageRequest pageRequest)
    {
        GetListCustomizedProductQuery query = new() { PageRequest = pageRequest };

        GetListResponse<GetListCustomizedProductListItemDto> response = await Mediator.Send(query);

        return Ok(response);
    }
}