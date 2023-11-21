using Endava.TechCourse.BankApp.Application.Queries.GetWalletsPerUser;
using Endava.TechCourse.BankApp.Domain.Models;
using Endava.TechCourse.BankApp.Infrastructure.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Endava.TechCourse.BankApp.Application.Queries.GetTransactions
{
    public class GetTransactionsHandler : IRequestHandler<GetTransactionsQuery, List<Transaction>>
    {
        private readonly ApplicationDbContext context;

        public GetTransactionsHandler(ApplicationDbContext context)
        {
            ArgumentNullException.ThrowIfNull(context);

            this.context = context;
        }

        public async Task<List<Transaction>> Handle(GetTransactionsQuery request, CancellationToken cancellationToken)
        {
            var transactions = await context.Transactions.Include(x=>x.SourceWallet).
                Include(x => x.DestinationWallet).
                Include(x => x.SourceUser).
                Include(x => x.DestinationUser).
                Include(x=>x.Currency).
                Where(x => x.SourceWallet.User.Id.ToString() == request.UserId).ToListAsync();

            return transactions;
        }
    }
}
