using Application.Features.TemplateProducts.Queries.GetById;
using Application.Features.TemplateProducts.Queries.GetList;
using NArchitecture.Core.Application.Requests;
using NArchitecture.Core.Application.Responses;
using Microsoft.AspNetCore.Mvc;
using Application.Features.PromptCategories.Commands.Create;
using Application.Features.PromptCategories.Commands.Delete;
using Application.Features.PromptCategories.Commands.Update;
using Application.Features.TemplateProducts.Command.Create;
using Application.Features.TemplateProducts.Command.Delete;
using Application.Features.TemplateProducts.Command.Update;
using Application.Features.TemplateProducts.Queries.GetDynamicList;
using NArchitecture.Core.Persistence.Dynamic;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class TemplateProductsController : BaseController
{

    [HttpPost]
    public async Task<ActionResult<CreatedTemplateProductResponse>> Add([FromBody] CreateTemplateProductCommand command)
    {

        CreatedTemplateProductResponse response = await Mediator.Send(command);

        return CreatedAtAction(nameof(GetById), new { response.Id }, response);
    }

    [HttpPut]
    public async Task<ActionResult<UpdatedTemplateProductResponse>> Update([FromBody] UpdateTemplateProductCommand command)
    {
        UpdatedTemplateProductResponse response = await Mediator.Send(command);

        return Ok(response);
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult<DeletedTemplateProductResponse>> Delete([FromRoute] Guid id)
    {
        DeleteTemplateProductCommand command = new() { TemplateId = id };

        DeletedTemplateProductResponse response = await Mediator.Send(command);

        return Ok(response);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<GetByIdTemplateProductResponse>> GetById([FromRoute] Guid id)
    {
        GetByIdTemplateProductQuery query = new() { Id = id };

        GetByIdTemplateProductResponse response = await Mediator.Send(query);

        return Ok(response);
    }

    [HttpGet]
    public async Task<ActionResult<GetListTemplateProductQuery>> GetList([FromQuery] PageRequest pageRequest)
    {
        GetListTemplateProductQuery query = new() { PageRequest = pageRequest };

        GetListResponse<GetListTemplateProductListItemDto> response = await Mediator.Send(query);

        return Ok(response);
    }

    [HttpPost ("dynamic")]
    public async Task<ActionResult<GetDynamicListTemplateProductQuery>> GetDynamicList([FromQuery] PageRequest pageRequest, [FromBody] DynamicQuery dynamicQuery)
    {
        GetDynamicListTemplateProductQuery query = new() { PageRequest = pageRequest , DynamicQuery = dynamicQuery};

        GetListResponse<GetDynamicListTemplateProductListItemDto> response = await Mediator.Send(query);

        return Ok(response);
    }
}