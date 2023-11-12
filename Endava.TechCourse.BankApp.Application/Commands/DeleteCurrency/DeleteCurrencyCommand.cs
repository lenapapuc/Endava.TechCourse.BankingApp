using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace Endava.TechCourse.BankApp.Application.Commands.DeleteWallet
{
    public class DeleteCurrencyCommand : IRequest<CommandStatus>
    {
        public Guid Id;
        public DeleteCurrencyCommand(Guid id) { this.Id = id; }
    }
}
