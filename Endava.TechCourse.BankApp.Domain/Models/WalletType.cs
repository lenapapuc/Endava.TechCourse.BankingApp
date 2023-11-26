using Endava.TechCourse.BankApp.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Endava.TechCourse.BankApp.Domain.Models
{
    public class WalletType : BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Commission {  get; set; }
    }
}
