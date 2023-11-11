using Endava.TechCourse.BankApp.Application.Commands.AddCurrency;
using Endava.TechCourse.BankApp.Shared;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Endava.TechCourse.BankApp.Server.Controllers
{
    [Route("api/currencies")]
    [ApiController]
    public class CurrencyController : ControllerBase
    {
        private readonly IMediator mediator;

        public CurrencyController(IMediator mediator)
        {
            ArgumentNullException.ThrowIfNull(mediator);

            this.mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> AddCurrency([FromBody] CurrencyDto dto)
        {
            var command = new AddCurrencyCommand()
            {
                Name = dto.Name,
                CurrencyCode = dto.CurrencyCode,
                ChangeRate = dto.ChangeRate
            };

            var result = await mediator.Send(command);

            return result.IsSuccessful ? Ok() : BadRequest(result.Error);
        }

        [HttpGet]
        public async Task<List<CurrencyDto>> GetCurrencies()
        {
            return new();
        }
    }
}