using Application.Features.Mockups.Commands.Create;
using Application.Features.Mockups.Queries.GetById;
using Infrastructure.Adapters.PrintfulService;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[Route("api/mockup")]
[ApiController]
public class MockupsController : BaseController
{
    private readonly PrintfulServiceAdapter printfulServiceAdapter;
    
    public MockupsController(PrintfulServiceAdapter _printfulServiceAdapter)
    {
        printfulServiceAdapter = _printfulServiceAdapter;
        
    }

    [HttpPost]
    public async Task<ActionResult<CreatedMockupResponse>> Add([FromBody] CreateMockupCommand command)
    {
        CreatedMockupResponse response = await Mediator.Send(command);

        return Ok(response.Response);
    }



    [HttpGet("{id}")]
    public async Task<ActionResult<GetByIdMockupResponse>> GetById([FromRoute] string id)
    {
        GetByIdMockupQuery query = new() { Id = id };

        GetByIdMockupResponse response = await Mediator.Send(query);

        return Ok(response.Response);
    }
}