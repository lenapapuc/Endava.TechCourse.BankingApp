using Endava.TechCourse.BankApp.Infrastructure.Persistence;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Endava.TechCourse.BankApp.Application.Commands.UpdateWallet
{
    public class UpdateWalletHandler : IRequestHandler<UpdateWalletCommand, CommandStatus>
    {
        private readonly ApplicationDbContext context;

        public UpdateWalletHandler(ApplicationDbContext context)
        {
            ArgumentNullException.ThrowIfNull(context);

            this.context = context;
        }

        public async Task<CommandStatus> Handle(UpdateWalletCommand request, CancellationToken cancellationToken)
        {
            var wallet = await context.Wallets.FirstOrDefaultAsync(w => w.Id == request.Id);
                if (wallet is null) return CommandStatus.Failed("Acest portofel nu exista");
            var currency = await context.Currencies.FirstOrDefaultAsync(x => x.CurrencyCode == request.Currency);
                if (currency is null)  return CommandStatus.Failed("Valuta pentru acest portofel nu exista");
            var walletType = await context.WalletTypes.FirstOrDefaultAsync(x => x.Name == request.Type);
                 if (walletType is null)  return CommandStatus.Failed("Acest tip nu exista");

            wallet.Currency = currency;
            wallet.Type = walletType;
            wallet.Amount = request.Amount;
            wallet.CurrencyId = currency.Id;
            
            await context.SaveChangesAsync(cancellationToken);
            return new CommandStatus();
            
        }
    }
}
