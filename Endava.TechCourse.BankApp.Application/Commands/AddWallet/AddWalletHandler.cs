using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Endava.TechCourse.BankApp.Application.Commands.AddCurrency;
using Endava.TechCourse.BankApp.Domain.Models;
using Endava.TechCourse.BankApp.Infrastructure.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Endava.TechCourse.BankApp.Application.Commands.AddWallet
{
    public class AddWalletHandler: IRequestHandler<AddWalletCommand, CommandStatus>
    {
        private readonly ApplicationDbContext context;

        public AddWalletHandler(ApplicationDbContext context)
        {
            ArgumentNullException.ThrowIfNull(context);

            this.context = context;
        }

        public async Task<CommandStatus> Handle(AddWalletCommand request, CancellationToken cancellationToken)
        {
           
            var currency = await context.Currencies.FirstOrDefaultAsync(x => x.CurrencyCode == request.Currency);

            if (currency is null)
                return CommandStatus.Failed("Valuta pentru acest portofel nu exista");

            var user = await context.Users.FirstOrDefaultAsync(x => x.Id.ToString() == request.UserId);

            var wallet = new Wallet()
            {
                Type = request.Type,
                Amount = new Random().Next(50,600),
                Currency = currency,
                CurrencyId = currency.Id,
                User = user
            };

            await context.Wallets.AddAsync(wallet, cancellationToken);
            await context.SaveChangesAsync(cancellationToken);

            return new CommandStatus();
        }

    }
}
