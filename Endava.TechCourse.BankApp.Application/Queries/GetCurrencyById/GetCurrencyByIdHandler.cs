using Endava.TechCourse.BankApp.Application.Queries.GetWallets;
using Endava.TechCourse.BankApp.Domain.Models;
using Endava.TechCourse.BankApp.Infrastructure.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Endava.TechCourse.BankApp.Application.Queries.GetWalletById
{
    public class GetCurrencyByIdHandler : IRequestHandler<GetCurrencyByIdQuery, Currency>
    {
        private readonly ApplicationDbContext context;

        public GetCurrencyByIdHandler(ApplicationDbContext context)
        { 
            ArgumentNullException.ThrowIfNull(context);
            this.context = context;
        }

        public async Task<Currency> Handle(GetCurrencyByIdQuery request, CancellationToken cancellationToken)
        {
            var currency = await context.Currencies
              .FirstOrDefaultAsync(w => w.Id == request.id);                       
            return currency;
        }
    }
}
