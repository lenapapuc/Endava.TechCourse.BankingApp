using Endava.TechCourse.BankApp.Domain.Common;

namespace Endava.TechCourse.BankApp.Domain.Models
{
    public class Wallet : BaseEntity
    {
        public WalletType Type { get; set; }

        public decimal Amount {get; set; }

        public Guid CurrencyId { get; set; }
        public Currency Currency { get; set; }
        public User User { get; set; }
    }
}