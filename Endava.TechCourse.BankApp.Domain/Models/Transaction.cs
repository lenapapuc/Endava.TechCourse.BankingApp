using Endava.TechCourse.BankApp.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Endava.TechCourse.BankApp.Domain.Models
{
    public class Transaction : BaseEntity
    {
        public Wallet SourceWallet { get; set; }
        public Wallet DestinationWallet { get; set; }
        public Currency Currency { get; set; }
        public string Type { get; set; }
        public string Description { get; set; }
        public decimal Amount { get; set; }
        public decimal Commission { get; set; }
        public string TransactionStatus { get; set; }

    }
}
