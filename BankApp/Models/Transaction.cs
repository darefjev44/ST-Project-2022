using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BankApp.Models
{
    public class Transaction
    {
        [Key]
        public Guid TransactionID { get; set; }
        // Foreign Key of BankAccount
        [Required]
        public Guid AccountID { get; set; }
        [Required]
        [Column(TypeName = "money")]
        public decimal TransactionAmount { get; set; }
        public string TransactionMessage { get; set; }
        [Required]
        public DateTime TransactionDate { get; set; }
    }
}
