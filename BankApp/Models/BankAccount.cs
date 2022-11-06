using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BankApp.Models
{
    public class BankAccount
    {
        [Key]
        public Guid AccountID { get; set; }
        // Foreign Key of Customer
        [Required]
        public Guid CustomerID { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        [Column(TypeName = "money")]
        public decimal Balance { get; set; }
        public List<Transaction>? Transactions { get; set; }
    }
}
