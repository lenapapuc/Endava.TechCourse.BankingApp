using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace Endava.TechCourse.BankApp.Application.Commands.DeleteWallet
{
    public class DeleteWalletCommand : IRequest<CommandStatus>
    {
        public Guid Id;
        public DeleteWalletCommand(Guid id) { this.Id = id; }
    }
}
