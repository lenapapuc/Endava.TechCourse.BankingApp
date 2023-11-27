using Endava.TechCourse.BankApp.Application.Commands.AddCurrency;
using Endava.TechCourse.BankApp.Application.Commands.AddWallet;
using Endava.TechCourse.BankApp.Application.Commands.CreateTransaction;
using Endava.TechCourse.BankApp.Application.Queries.GetTransactions;
using Endava.TechCourse.BankApp.Application.Queries.GetWalletsPerUser;
using Endava.TechCourse.BankApp.Server.Common;
using Endava.TechCourse.BankApp.Server.Common.JWToken;
using Endava.TechCourse.BankApp.Shared;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Endava.TechCourse.BankApp.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransactionsController : ControllerBase
    {
        private readonly IMediator mediator;

        public TransactionsController(IMediator mediator)
        {
            ArgumentNullException.ThrowIfNull(mediator);

            this.mediator = mediator;
        }

        [HttpPost]
        [Authorize(Roles = "USER")]
        public async Task<IActionResult> CreateTransaction([FromBody] TransactionDto dto)
        {
            var userIdClaim = HttpContext.User.Claims.FirstOrDefault(x => x.Type == Constants.UserIdClaimName);
            if (userIdClaim is null)
                return BadRequest("Not authorized");

            var userId = userIdClaim.Value;
            var command = new CreateTransactionCommand()
            {
                SourceWallet = dto.SourceWallet,
                DestinationWallet = dto.DestinationWallet,
                Amount = dto.Amount,
                Description = dto.Description,
                Type = dto.Type,
                Commission = dto.Commission,
                Currency = dto.Currency,
                TransactionStatus = dto.TransactionStatus,
                SourceUserId = userId
                
            };

            var result = await mediator.Send(command);

            return result.IsSuccessful ? Ok() : BadRequest(result.Error);

        }

        [HttpGet]
        [Authorize(Roles = "USER")]
        public async Task<List<TransactionDto>> GetTransactionsPerUser()
        {
            var userIdClaim = HttpContext.User.Claims.FirstOrDefault(x => x.Type == Constants.UserIdClaimName);

            if (userIdClaim is null)
                return new List<TransactionDto>();

            var userId = userIdClaim.Value;

            var query = new GetTransactionsQuery()
            {
                UserId = userId
            };
            var transactions = await mediator.Send(query);

            return Mapper.Map(transactions);
        }
    }
}
