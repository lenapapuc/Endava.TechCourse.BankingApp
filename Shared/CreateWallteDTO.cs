using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Endava.TechCourse.BankApp.Shared
{
    public class CreateWallteDTO
    {
        public string Type {  get; set; }
        public decimal Amount {  get; set; }
        public CreateCurrencyDTO Currency { get; set; }
    }
}
