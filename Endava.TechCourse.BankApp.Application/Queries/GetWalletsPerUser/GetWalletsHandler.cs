using Endava.TechCourse.BankApp.Domain.Models;
using Endava.TechCourse.BankApp.Infrastructure.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Endava.TechCourse.BankApp.Application.Queries.GetWalletsPerUser
{
    public class GetWalletsPerUserHandler : IRequestHandler<GetWalletsPerUserQuery, List<Wallet>>
    {
        private readonly ApplicationDbContext context;

        public GetWalletsPerUserHandler(ApplicationDbContext context)
        {
            ArgumentNullException.ThrowIfNull(context);

            this.context = context;
        }

        public async Task<List<Wallet>> Handle(GetWalletsPerUserQuery request, CancellationToken cancellationToken)
        {
            var wallets = await context.Wallets.Include(x => x.Currency).Include(x => x.Type)
                .Where(x=>x.User.Id.ToString() == request.UserId)
                .ToListAsync(cancellationToken: cancellationToken);

            return wallets;
        }
    }
}