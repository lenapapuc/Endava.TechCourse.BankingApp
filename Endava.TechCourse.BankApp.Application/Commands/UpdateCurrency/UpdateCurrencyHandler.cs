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
    public class UpdateCurrencyHandler : IRequestHandler<UpdateCurrencyCommand, CommandStatus>
    {
        private readonly ApplicationDbContext context;

        public UpdateCurrencyHandler(ApplicationDbContext context)
        {
            ArgumentNullException.ThrowIfNull(context);

            this.context = context;
        }

        public async Task<CommandStatus> Handle(UpdateCurrencyCommand request, CancellationToken cancellationToken)
        {
            var currency = await context.Currencies.FirstOrDefaultAsync(c => c.Id == request.Id);
                if (currency is null) return CommandStatus.Failed("Aceasta valuta nu exista");
          
            currency.Name = request.Name;
            currency.ChangeRate = request.ChangeRate;
            currency.CurrencyCode = request.CurrencyCode;    
            
            await context.SaveChangesAsync(cancellationToken);
            return new CommandStatus();
            
        }
    }
}
