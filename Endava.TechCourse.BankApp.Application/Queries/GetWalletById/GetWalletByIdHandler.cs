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
    public class GetWalletByIdHandler : IRequestHandler<GetWalletByIdQuery, Wallet>
    {
        private readonly ApplicationDbContext context;

        public GetWalletByIdHandler(ApplicationDbContext context)
        { 
            ArgumentNullException.ThrowIfNull(context);
            this.context = context;
        }

        public async Task<Wallet> Handle(GetWalletByIdQuery request, CancellationToken cancellationToken)
        {
            var wallet = await context.Wallets
                .Include(w => w.Currency).Include(w =>w.Type).FirstOrDefaultAsync(w => w.Id == request.id);                       
            return wallet;
        }
    }
}
