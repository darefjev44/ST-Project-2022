using System.ComponentModel.DataAnnotations;
using System.Web;
using System.ComponentModel;

namespace BankApp.Models
{
    /*
     * This model is intended for use in the registration form
     */
    public class LoginViewModel
    {
        [DisplayName("User ID")]
        [Required]
        public string? UserID { get; set; }

        [Required]
        public string? PIN { get; set; }
    }
}
