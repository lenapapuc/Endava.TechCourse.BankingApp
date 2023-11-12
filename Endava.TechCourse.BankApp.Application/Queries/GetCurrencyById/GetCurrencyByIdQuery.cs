using Endava.TechCourse.BankApp.Domain.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Endava.TechCourse.BankApp.Application.Queries.GetWalletById
{
    public class GetCurrencyByIdQuery : IRequest<Currency>
    {
        public Guid id;

        public GetCurrencyByIdQuery(Guid id)
        {
            this.id = id;
        }
    }
}
