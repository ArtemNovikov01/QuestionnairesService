using MediatR;
using Microsoft.AspNetCore.Mvc;
using QuestionnairesService.Application.Businessmans.Commands.CreateBusinessman;
using QuestionnairesService.Application.Businessmans.Commands.CreateBusinessman.Models;
using QuestionnairesService.Application.Businessmans.Querys.GetInfoByBin;
using QuestionnairesService.Application.Businessmans.Querys.GetInfoByInn;

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

    [HttpPost("getInfoByInn")]
    public async Task<GetInfoByInnResponse> CreateBusinessman(GetInfoByInnQuery query)
    {
        return await _mediator.Send(query, HttpContext.RequestAborted);
    }

    [HttpPost("getInfoByBin")]
    public async Task<GetInfoByBinResponse> CreateBusinessman(GetInfoByBinQuery query)
    {

        return await _mediator.Send(query, HttpContext.RequestAborted);
    }
}

public class CreateBusinessmanRequest
{
    public IFormFile SkanINN { get; set; } = null!;
    public IFormFile SkanRegistrationNumber { get; set; } = null!;
    public IFormFile SkanExtractFromTax { get; set; } = null!;
    public IFormFile SkanContractRent { get; set; } = null!;
    public BuisnessmenDto BuisnessmanInfo { get; set; } = null!;
}
