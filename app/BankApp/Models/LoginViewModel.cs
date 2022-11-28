using System.ComponentModel.DataAnnotations;
using System.Web;
using System.ComponentModel;

namespace BankApp.Models
{
    public class LoginViewModel
    {
        [DisplayName("User ID")]
        [Required]
        public string? UserID { get; set; }

        [Required]
        [StringLength(6, MinimumLength = 6, ErrorMessage = "All PIN digits must be filled.")]
        public string? PIN { get; set; }
    }
}
