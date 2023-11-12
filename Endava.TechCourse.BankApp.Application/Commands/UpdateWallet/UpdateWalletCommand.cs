using MediatR;
using Microsoft.Identity.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Endava.TechCourse.BankApp.Application.Commands.UpdateWallet
{
    public class UpdateWalletCommand : IRequest<CommandStatus>
    {
        public Guid Id;
        public string Type { get; set; }
        public decimal Amount { get; set; }
        public string Currency { get; set; }

        public UpdateWalletCommand(Guid id) { Id = id; }
    }
}
