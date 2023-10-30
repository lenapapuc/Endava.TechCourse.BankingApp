using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Endava.TechCourse.BankApp.Shared
{
    public class CreateCurrencyDTO
    {
        public string CurrencyCode { get; set;}
        public string CurrencyName { get; set;}
        public decimal ChangeRate { get; set; }
    }
}
