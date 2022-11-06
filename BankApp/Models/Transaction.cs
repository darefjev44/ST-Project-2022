namespace BankApp.Models
{
    public class Transaction
    {
        public Guid TransactionID { get; set; }
        public decimal TransactionAmount { get; set; }
        public string TransactionMessage { get; set; }
        public DateTime TransactionDate { get; set; }
    }
}
