using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Endava.TechCourse.BankApp.Shared
{
    public class WalletDTO
    {
        public string Id { get; set; }   
        public string Type { get; set; }
        public string Currency { get; set; }
        public decimal Amount { get; set; }
    }
}
