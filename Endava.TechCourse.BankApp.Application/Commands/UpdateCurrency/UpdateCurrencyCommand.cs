using MediatR;
using Microsoft.Identity.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Endava.TechCourse.BankApp.Application.Commands.UpdateWallet
{
    public class UpdateCurrencyCommand : IRequest<CommandStatus>
    {
        public Guid Id;
        public string Name { get; set; }
        public string CurrencyCode { get; set; }
        public decimal ChangeRate { get; set; }

        public UpdateCurrencyCommand(Guid id) { Id = id; }
    }
}
