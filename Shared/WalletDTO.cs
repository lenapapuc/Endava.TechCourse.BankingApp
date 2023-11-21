namespace Endava.TechCourse.BankApp.Shared
{
    public class WalletDto
    {
        public string Id { get; set; }
        public string Type { get; set; }
        public decimal Amount { get; set; }
        public string Currency { get; set; }
        public decimal ChangeRate { get; set; }
        public string UserId { get; set; }
        public string LastNameofUser { get; set; }
        public string FirstNameofUser { get; set; }
    }
}