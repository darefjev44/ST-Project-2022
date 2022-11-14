using System.ComponentModel.DataAnnotations;
using System.Web;
using System.ComponentModel;

namespace BankApp.Models
{
    /*
     * This model is intended for use in the registration form
     */
    public class AccountViewModel
    {
        [Key]
        public int UserID { get; set; }

        //Account Signup Information
        [Required(ErrorMessage = "First name is required.")]
        [RegularExpression("^[a-zA-Z ]*$")]
        public string FirstName { get; set; }


        [Required(ErrorMessage = "Surname is required.")]
        [RegularExpression("^[a-zA-Z ]*$")]
        public string LastName { get; set; }


        [Required(ErrorMessage = "Address is required.")]
        public string Address1 { get; set; }


        public string? Address2 { get; set; }


        [Required(ErrorMessage = "City is required.")]
        public string City { get; set; }


        [Required(ErrorMessage = "County is required.")]
        public string County { get; set; }


        [Required(ErrorMessage = "Eircode is required.")]
        [StringLength(7, MinimumLength = 7, ErrorMessage = "Invalid eircode has been entered.")]
        public string Eircode { get; set; }


        [Required(ErrorMessage = "Phone number is required.")]
        //Replacing DataType.PhoneNumber with regex as it doesn't really work correctly. Source: https://ihateregex.io/expr/phone/
        [RegularExpression("^[\\+]?[(]?[0-9]{3}[)]?[-\\s\\.]?[0-9]{3}[-\\s\\.]?[0-9]{4,6}$", ErrorMessage = "Invalid phone number has been entered.")]
        public string PhoneNumber { get; set; }


        [Required(ErrorMessage = "Email is required.")]
        [DataType(DataType.EmailAddress, ErrorMessage = "Invalid Email has been entered.")]
        public string Email { get; set; }
    }
}
