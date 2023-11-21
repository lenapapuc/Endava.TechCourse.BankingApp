using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Endava.TechCourse.BankApp.Application.Commands.AddWallet
{
    public class AddWalletCommand : IRequest<CommandStatus>
    {
        public string Type { get; set; }
        public decimal Amount { get; set; }
        public string Currency { get; set; }
        public string UserId { get; set; }

    }
}
