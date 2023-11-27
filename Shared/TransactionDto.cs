using System;

namespace Endava.TechCourse.BankApp.Shared
{
    public class TransactionDto
    {
        public string Id { get; set; }
        public string SourceWallet { get; set; }
        public string DestinationWallet { get; set; }
        public string Currency { get; set; }
        public string Type { get; set; }
        public string Description { get; set; }
        public decimal Amount { get; set; }
        public decimal Commission { get; set; }
        public string TransactionStatus { get; set; }
        public DateTime TransactionTime { get; set; }
        public string SourceUserId {  get; set; }
        public string DestinationUserId { get; set; }
        public string SourceLastName { get; set; }
        public string DestinationLastName {  get; set; }
    }
}