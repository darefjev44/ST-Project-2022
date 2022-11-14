using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BankApp.Models
{
    public class TransactionModel
    {
        //PK
        [Key]
        [Required]
        public int TransactionID { get; set; }

        /* Not sure if this is actually required?
         * 
        //FK - I messed up here I think.
        [Required]
        [ForeignKey("Account")]
        public int AccountID { get; set; }
        public virtual AccountModel Account { get; set; }
        */

        [Required]
        public decimal Amount { get; set; }

        public string Message { get; set; }

        [Required]
        public DateOnly Date { get; set; }
    }
}
