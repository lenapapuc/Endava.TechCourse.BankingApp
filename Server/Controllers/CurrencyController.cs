using Endava.TechCourse.BankApp.Domain.Models;
using Endava.TechCourse.BankApp.Infrastructure.Persistence;
using Endava.TechCourse.BankApp.Server.Common;
using Endava.TechCourse.BankApp.Shared;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Endava.TechCourse.BankApp.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CurrenciesController : ControllerBase
    {
        private readonly ApplicationDbContext context;

        public CurrenciesController(ApplicationDbContext context)
        {
            ArgumentNullException.ThrowIfNull(context);
            this.context = context;
        }

        [HttpPost]
        public IActionResult CreateCurrency([FromBody] CurrencyDto currencyDto)
        {
            var currency = new Currency
            {
                Name = currencyDto.Name,
                CurrencyCode = currencyDto.CurrencyCode,
                ChangeRate = currencyDto.ChangeRate
            };

            context.Currencies.Add(currency);
            context.SaveChanges();

            return Ok();
        }

        [HttpGet]
        public async Task<List<CurrencyDto>> GetCurrencies()
        {
            var currencies = await context.Currencies.ToListAsync();
            var dtos = Mapper.Map(currencies).ToList();

            return dtos;
        }
      
    }
}
