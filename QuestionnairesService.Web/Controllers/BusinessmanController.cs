using MediatR;
using Microsoft.AspNetCore.Mvc;
using QuestionnairesService.Application.Businessmans.Commands.CreateBusinessman;

namespace QuestionnairesService.Web.Controllers;

[ApiController]
[Route("api/[controller]")]
public class BusinessmanController : ControllerBase
{
    private readonly IMediator _mediator;

    public BusinessmanController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost("createBusinessman")]
    public Task<CreateBusinessmanResponse> CreateBusinessman(CreateBusinessmanCommand command)
    {
        return _mediator.Send(command, HttpContext.RequestAborted);
    }
}
