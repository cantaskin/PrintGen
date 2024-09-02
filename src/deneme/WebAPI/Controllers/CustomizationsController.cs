using Application.Features.Customizations.Commands.Create;
using Application.Features.Customizations.Commands.Delete;
using Application.Features.Customizations.Commands.Update;
using Application.Features.Customizations.Queries.GetById;
using Application.Features.Customizations.Queries.GetList;
using NArchitecture.Core.Application.Requests;
using NArchitecture.Core.Application.Responses;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CustomizationsController : BaseController
{
    [HttpPost]
    public async Task<ActionResult<CreatedCustomizationResponse>> Add([FromBody] CreateCustomizationCommand command)
    {
        CreatedCustomizationResponse response = await Mediator.Send(command);

        return CreatedAtAction(nameof(GetById), new { response.Id }, response);
    }

    [HttpPut]
    public async Task<ActionResult<UpdatedCustomizationResponse>> Update([FromBody] UpdateCustomizationCommand command)
    {
        UpdatedCustomizationResponse response = await Mediator.Send(command);

        return Ok(response);
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult<DeletedCustomizationResponse>> Delete([FromRoute] Guid id)
    {
        DeleteCustomizationCommand command = new() { Id = id };

        DeletedCustomizationResponse response = await Mediator.Send(command);

        return Ok(response);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<GetByIdCustomizationResponse>> GetById([FromRoute] Guid id)
    {
        GetByIdCustomizationQuery query = new() { Id = id };

        GetByIdCustomizationResponse response = await Mediator.Send(query);

        return Ok(response);
    }

    [HttpGet]
    public async Task<ActionResult<GetListCustomizationQuery>> GetList([FromQuery] PageRequest pageRequest)
    {
        GetListCustomizationQuery query = new() { PageRequest = pageRequest };

        GetListResponse<GetListCustomizationListItemDto> response = await Mediator.Send(query);

        return Ok(response);
    }
}