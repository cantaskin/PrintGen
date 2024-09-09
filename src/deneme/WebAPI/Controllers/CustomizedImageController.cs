using Application.Features.Customizations.Commands.Delete;
using Application.Features.Customizations.Queries.GetList;
using Application.Features.CustomizedImages.Commands.Create;
using Application.Features.CustomizedImages.Commands.Delete;
using Application.Features.CustomizedImages.Queries.GetById;
using Application.Features.CustomizedImages.Queries.GetList;
using Application.Features.Gifts.Commands.Delete;
using Application.Features.Gifts.Queries.GetById;
using Application.Features.Gifts.Queries.GetList;
using Application.Features.Prompts.Commands.Create;
using Infrastructure.Adapters.PrintfulService;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NArchitecture.Core.Application.Requests;
using NArchitecture.Core.Application.Responses;

namespace WebAPI.Controllers;
[Route("Deneme/[controller]")]
[ApiController]
public class CustomizedImageController : BaseController
{

    [HttpPost("/RemoveBackground")]
    public async Task<ActionResult<CreatedCustomizedImageRemoveBackgroundResponse>> RemoveBackground([FromBody] CreateCustomizedImageRemoveBackgroundCommand command)
    {
       // CreateCustomizedImageRemoveBackgroundCommand command = new() { Id = id };
     
        CreatedCustomizedImageRemoveBackgroundResponse response = await Mediator.Send(command);
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
