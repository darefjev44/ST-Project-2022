using System.ComponentModel.DataAnnotations;
using System.Web;
using System.ComponentModel;

namespace BankApp.Models
{
    /*
     * This model is intended for use in the registration form
     */
    public class RegisterViewModel
    {
        //Account Signup Information
        [Required(ErrorMessage = "First name is required.")]
        [RegularExpression("^[a-zA-Z ]*$", ErrorMessage = "First name must contain only letters and spaces.")]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "First name must be between 2 and 50 characters.")]
        public string? FirstName { get; set; }


        [Required(ErrorMessage = "Surname is required.")]
        [RegularExpression("^[a-zA-Z ]*$", ErrorMessage = "Surname must contain only letters and spaces.")]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "Surname must be between 2 and 50 characters.")]
        public string? LastName { get; set; }


        [Required(ErrorMessage = "Address is required.")]
        public string? Address1 { get; set; }


        public string? Address2 { get; set; }


        [Required(ErrorMessage = "City is required.")]
        public string? City { get; set; }


        [Required(ErrorMessage = "County is required.")]
        public string? County { get; set; }


        [Required(ErrorMessage = "Eircode is required.")]
        [RegularExpression("^([A-Za-z0-9]{3}\\s{0,1}[A-Za-z0-9]{4})$", ErrorMessage = "Invalid eircode has been entered.")]
        public string? Eircode { get; set; }


        [Required(ErrorMessage = "Phone number is required.")]
        //Replacing DataType.PhoneNumber with regex as it doesn't really work correctly. Source: https://ihateregex.io/expr/phone/
        [RegularExpression("^[\\+]?[(]?[0-9]{3}[)]?[-\\s\\.]?[0-9]{3}[-\\s\\.]?[0-9]{4,6}$", ErrorMessage = "Invalid phone number has been entered.")]
        public string? PhoneNumber { get; set; }


        [Required(ErrorMessage = "Email is required.")]
        [EmailAddress(ErrorMessage = "Invalid Email has been entered.")]
        public string? Email { get; set; }
    }
}
