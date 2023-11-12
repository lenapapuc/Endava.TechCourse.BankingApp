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
    public class DeleteWalletHandler : IRequestHandler<DeleteWalletCommand, CommandStatus>
    {
        private readonly ApplicationDbContext context;
        public DeleteWalletHandler(ApplicationDbContext context) { 
            ArgumentNullException.ThrowIfNull(context); 
            this.context = context; }

        public async Task<CommandStatus> Handle(DeleteWalletCommand request, CancellationToken cancellation)
        {
            var wallet = await context.Wallets.FirstOrDefaultAsync(w => w.Id == request.Id);
            if (wallet is null) return CommandStatus.Failed("Portofelul pe care doriti sa-l stergeti nu exista!");

            context.Wallets.Remove(wallet);
            await context.SaveChangesAsync();
            return new CommandStatus();
        }
    }
}
