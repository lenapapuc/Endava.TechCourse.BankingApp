using Endava.TechCourse.BankApp.Application.Commands.AddWallet;
using Endava.TechCourse.BankApp.Application.Commands.DeleteWallet;
using Endava.TechCourse.BankApp.Application.Commands.UpdateWallet;
using Endava.TechCourse.BankApp.Application.Queries.GetWalletById;
using Endava.TechCourse.BankApp.Application.Queries.GetWallets;
using Endava.TechCourse.BankApp.Application.Queries.GetWalletsPerUser;
using Endava.TechCourse.BankApp.Domain.Models;
using Endava.TechCourse.BankApp.Infrastructure.Persistence;
using Endava.TechCourse.BankApp.Server.Common;
using Endava.TechCourse.BankApp.Server.Common.JWToken;
using Endava.TechCourse.BankApp.Shared;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Endava.TechCourse.BankApp.Server.Controllers
{
    [Route("api/wallets")]
    [ApiController]
    public class WalletsController : ControllerBase
    {
        private readonly ApplicationDbContext context;
        private readonly IMediator mediator;

        public WalletsController(ApplicationDbContext context, IMediator mediator)
        {
            ArgumentNullException.ThrowIfNull(context);
            ArgumentNullException.ThrowIfNull(mediator);

            this.context = context;
            this.mediator = mediator;
        }

        [HttpGet]
        [Authorize(Roles = "USER")]
        public async Task<List<WalletDto>> GetWalletsPerUser()
        {
            var userIdClaim = HttpContext.User.Claims.FirstOrDefault(x => x.Type == Constants.UserIdClaimName);

            if (userIdClaim is null)
                return new List<WalletDto>();

            var userId = userIdClaim.Value;

            var query = new GetWalletsPerUserQuery()
            {
                UserId = userId
            };
            var wallets = await mediator.Send(query);

            return Mapper.Map1(wallets);
        }

        [HttpGet]
       [ Route("all")]
        [Authorize(Roles = "ADMIN")]
        public async Task<List<WalletDto>> GetWallets()
        {

            var query = new GetWalletsQuery();
            
            var wallets = await mediator.Send(query);

            return Mapper.Map(wallets);
        }

        [HttpPost]
        [Authorize(Roles = "USER")]
        public async Task<IActionResult> CreateWallet([FromBody] WalletDto walletDto)
        {
            var userIdClaim = HttpContext.User.Claims.FirstOrDefault(x => x.Type == Constants.UserIdClaimName);
            if (userIdClaim is null)
                return BadRequest("Not authorized");

            var userId = userIdClaim.Value;

            var command = new AddWalletCommand()
            {
                Type = walletDto.Type,
                Amount = walletDto.Amount,
                Currency = walletDto.Currency,
                UserId = userId
            };

            var result = await mediator.Send(command);

            return result.IsSuccessful ? Ok() : BadRequest(result.Error);
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<WalletDto> GetWalletById(Guid id)
        {
            var query = new GetWalletByIdQuery(id);
            var wallet = await mediator.Send(query);

            return Mapper.Map(wallet);
        }

        [HttpPut]
        [Route("{id}")]
        public async  Task<IActionResult> UpdateWallet([FromBody] WalletDto walletDto, Guid id)
        {
            var command = new UpdateWalletCommand(id)
            {
                Type = walletDto.Type,
                Amount = walletDto.Amount,
                Currency = walletDto.Currency,
            };
            var result = await mediator.Send(command);
            return result.IsSuccessful ? Ok() : BadRequest(result.Error);
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> DeleteWallet(Guid id)
        {
            var command = new DeleteWalletCommand(id);
            var result = await mediator.Send(command);
            return result.IsSuccessful ? Ok() : BadRequest(result.Error);
        }
    }
}