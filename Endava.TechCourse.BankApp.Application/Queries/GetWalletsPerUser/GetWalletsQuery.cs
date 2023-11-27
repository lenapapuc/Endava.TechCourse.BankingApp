using Endava.TechCourse.BankApp.Domain.Models;
using MediatR;

namespace Endava.TechCourse.BankApp.Application.Queries.GetWalletsPerUser
{
    public class GetWalletsPerUserQuery : IRequest<List<Wallet>>
    {
        public string UserId;
    }
}