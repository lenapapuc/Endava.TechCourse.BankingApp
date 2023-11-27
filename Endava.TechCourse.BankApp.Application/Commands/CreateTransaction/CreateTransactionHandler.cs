using Endava.TechCourse.BankApp.Application.Commands.AddCurrency;
using Endava.TechCourse.BankApp.Domain.Models;
using Endava.TechCourse.BankApp.Infrastructure.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Endava.TechCourse.BankApp.Application.Commands.CreateTransaction
{
    public class CreateTransactionHandler : IRequestHandler<CreateTransactionCommand, CommandStatus>
    {
        private readonly ApplicationDbContext context;

        public CreateTransactionHandler(ApplicationDbContext context)
        {
            ArgumentNullException.ThrowIfNull(context);

            this.context = context;
        }

        public async Task<CommandStatus> Handle(CreateTransactionCommand request, CancellationToken cancellationToken)
        {

            var sourceWallet = await context.Wallets.Include(x => x.Currency).FirstOrDefaultAsync(x => x.Id.ToString() == request.SourceWallet);

            if (sourceWallet is null)
                return CommandStatus.Failed("Portofelul sursa nu exista");

            var destinationWallet = await context.Wallets.
                Include(x => x.User).
                Include(x => x.Currency).
                FirstOrDefaultAsync(x => x.Id.ToString() == request.DestinationWallet);

            if (destinationWallet is null)
                return CommandStatus.Failed("Portofelul destinatie nu exista");
             

            if(request.Amount + request.Commission > sourceWallet.Amount)
                return CommandStatus.Failed("Fonduri insuficiente");

            var sourceUser = await context.Users.FirstOrDefaultAsync(x => x.Id.ToString() == request.SourceUserId);
            var commision = 0;

            if (sourceUser != destinationWallet.User) commision = 1;

            var transaction = new Transaction()
            {
                SourceWallet = sourceWallet,
                DestinationWallet = destinationWallet,
                Currency = sourceWallet.Currency,
                Type = request.Type,
                Description = request.Description,
                Amount  = request.Amount,
                Commission = commision,
                TransactionStatus = request.TransactionStatus,
                SourceUser = sourceUser,
                DestinationUser = destinationWallet.User
                
          };
            sourceWallet.Amount = sourceWallet.Amount - transaction.Amount;

            if (sourceWallet.Currency == destinationWallet.Currency)
                destinationWallet.Amount = destinationWallet.Amount + transaction.Amount;
            
            else
            {
                var amountInNationalCurrency = request.Amount * sourceWallet.Currency.ChangeRate;
                destinationWallet.Amount = amountInNationalCurrency / destinationWallet.Currency.ChangeRate;

            }

            

            await context.Transactions.AddAsync(transaction, cancellationToken);
            await context.SaveChangesAsync(cancellationToken);

            return new CommandStatus();
        }
    }
}