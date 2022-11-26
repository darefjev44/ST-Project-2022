using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BankApp.Models
{
    public class TransactionModel
    {
        public TransactionModel(decimal amount, string message, DateTime date)
        {
            Amount = amount;
            Message = message;
            Date = date;
        }

        [Key]
        [Required]
        public int TransactionID { get; set; }

        public virtual ApplicationUser ApplicationUser { get; set; }

        [Column(TypeName = "decimal(10,2)")]
        public decimal Amount { get; set; }

        public string Message { get; set; }

        public DateTime Date { get; set; }
    }
}
