using Application.Features.CustomizedImages.Commands.Create;
using Application.Features.Prompts.Commands.Create;
using Infrastructure.Adapters.PrintfulService;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;
[Route("Deneme/[controller]")]
[ApiController]
public class CustomizedImageController : BaseController
{


    [HttpPost("/RemoveBackground")]
    public async Task<ActionResult<CreatedCustomizedImageRemoveBackgroundResponse>> RemoveBackground([FromBody] CreateCustomizedImageRemoveBackgroundCommand command)
    {

        CreatedCustomizedImageRemoveBackgroundResponse response = await Mediator.Send(command);
        return Ok(response);

    }
}
