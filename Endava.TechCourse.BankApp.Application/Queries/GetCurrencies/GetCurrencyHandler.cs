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

namespace Endava.TechCourse.BankApp.Application.Queries.GetCurrencies
{
    public class GetCurrencyHandler : IRequestHandler<GetCurrencyQuery, List<Currency>>
    {
        private readonly ApplicationDbContext context;

        public GetCurrencyHandler(ApplicationDbContext context)
        {
            ArgumentNullException.ThrowIfNull(context);

            this.context = context;
        }

        public async Task<List<Currency>> Handle(GetCurrencyQuery request, CancellationToken cancellationToken)
        {
            var currencies = await context.Currencies.ToListAsync();

            return currencies;
        }
    }
}
