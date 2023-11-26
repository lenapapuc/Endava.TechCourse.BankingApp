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

            if (user is null)
                return CommandStatus.Failed("Acest utilizator nu exista ");

            var walletType = await context.WalletTypes.FirstOrDefaultAsync(x => x.Name == request.Type);

            if (walletType is null)
                return CommandStatus.Failed("Acest tip nu exista");


            if (walletType is null)
                return CommandStatus.Failed("Nu exista astfel de tip de portofel digital");

            var wallet = new Wallet()
            {
                Type = walletType,
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
