using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Endava.TechCourse.BankApp.Application.Commands.CreateTransaction
{
    public class CreateTransactionCommand : IRequest<CommandStatus>
    {
       
        public string SourceWallet { get; set; }
        public string DestinationWallet { get; set; }
        public string Currency { get; set; }
        public string Type { get; set; }
        public string Description { get; set; }
        public decimal Amount { get; set; }
        public decimal Commission { get; set; }
        public string TransactionStatus { get; set; }
        public DateTime TransactionTime { get; set; }
        public string SourceUserId { get; set; }
       
    }
}
