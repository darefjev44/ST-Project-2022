using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BankApp.Models
{
    public class DepositViewModel
    {
        [Required]
        [Range(0.01, 500.00,
            ErrorMessage = "Amount must be between 0.01 and 500.00")]
        public decimal Amount { get; set; }
    }
}
