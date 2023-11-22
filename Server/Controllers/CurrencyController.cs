using Endava.TechCourse.BankApp.Application.Commands.AddCurrency;
using Endava.TechCourse.BankApp.Application.Commands.DeleteWallet;
using Endava.TechCourse.BankApp.Application.Commands.UpdateWallet;
using Endava.TechCourse.BankApp.Application.Queries.GetCurrencies;
using Endava.TechCourse.BankApp.Application.Queries.GetWalletById;
using Endava.TechCourse.BankApp.Application.Queries.GetWallets;
using Endava.TechCourse.BankApp.Server.Common;
using Endava.TechCourse.BankApp.Shared;
using MediatR;
using Microsoft.AspNetCore.Authorization;
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
        [Authorize(Roles = "ADMIN")]
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
            var query = new GetCurrencyQuery();
            var currencies = await mediator.Send(query);

            return Mapper.Map(currencies);
        }


        [HttpGet]
        [Route("{id}")]
        public async Task<CurrencyDto> GetCurrencyById(Guid id)
        {
            var query = new GetCurrencyByIdQuery(id);
            var currency = await mediator.Send(query);

            return Mapper.Map(currency);
        }

        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> UpdateCurrency([FromBody] CurrencyDto currencyDto, Guid id)
        {
            var command = new UpdateCurrencyCommand(id)
            {
                Name=currencyDto.Name,  
                CurrencyCode=currencyDto.CurrencyCode,
                ChangeRate=currencyDto.ChangeRate
            };
            var result = await mediator.Send(command);
            return result.IsSuccessful ? Ok() : BadRequest(result.Error);
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> DeleteCurrency(Guid id)
        {
            var command = new DeleteCurrencyCommand(id);
            var result = await mediator.Send(command);
            return result.IsSuccessful ? Ok() : BadRequest(result.Error);
        }
    }
}