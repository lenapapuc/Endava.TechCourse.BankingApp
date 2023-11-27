using Endava.TechCourse.BankApp.Application.Commands;
using Endava.TechCourse.BankApp.Domain.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Endava.TechCourse.BankApp.Application.Queries.GetCurrencies
{
    public class GetCurrencyQuery : IRequest<List<Currency>>
    {
    }
}
