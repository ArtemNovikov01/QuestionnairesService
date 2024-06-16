using MediatR;
using Microsoft.AspNetCore.Mvc;
using QuestionnairesService.Application.Businessmans.Commands.CreateBusinessman;
using QuestionnairesService.Application.Businessmans.Commands.CreateBusinessman.Models;

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
    public async Task<CreateBusinessmanResponse> CreateBusinessman(CreateBusinessmanRequest newBuisnessman)
    {
        await using Stream skanINNStream = newBuisnessman.SkanINN.OpenReadStream();

        await using Stream skanRegistrationNumberStream = newBuisnessman.SkanRegistrationNumber.OpenReadStream();

        await using Stream skanExtractFromTaxStream = newBuisnessman.SkanExtractFromTax.OpenReadStream();

        await using Stream skanContractRentStream = newBuisnessman.SkanContractRent.OpenReadStream();

        var command = new CreateBusinessmanCommand
        {
            BuisnessmenDto = newBuisnessman.BuisnessmanInfo,
            SkanINN = skanINNStream,
            SkanRegistrationNumber = skanRegistrationNumberStream,
            SkanExtractFromTax = skanExtractFromTaxStream,
            SkanContractRent = skanContractRentStream
        };

        return await _mediator.Send(command, HttpContext.RequestAborted);
    }
}
public class CreateBusinessmanRequest
{
    public IFormFile SkanINN { get; set; }
    public IFormFile SkanRegistrationNumber { get; set; }
    public IFormFile SkanExtractFromTax { get; set; }
    public IFormFile SkanContractRent { get; set; }
    public BuisnessmenDto BuisnessmanInfo { get; set; }
}
