using Endava.TechCourse.BankApp.Infrastructure.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Endava.TechCourse.BankApp.Application.Commands.DeleteWallet
{
    public class DeleteCurrencyHandler : IRequestHandler<DeleteCurrencyCommand, CommandStatus>
    {
        private readonly ApplicationDbContext context;
        public DeleteCurrencyHandler(ApplicationDbContext context) { 
            ArgumentNullException.ThrowIfNull(context); 
            this.context = context; }

        public async Task<CommandStatus> Handle(DeleteCurrencyCommand request, CancellationToken cancellation)
        {
            var currency = await context.Currencies.Include(x=>x.Wallets).FirstOrDefaultAsync(w => w.Id == request.Id);
            if (currency is null) return CommandStatus.Failed("Valuta pe care doriti s-o stergeti nu exista!");
            //Remove all currencies and their associated Wallets
            context.Currencies.Remove(currency);
            await context.SaveChangesAsync();
            return new CommandStatus();
        }
    }
}
