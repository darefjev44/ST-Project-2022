using System.ComponentModel.DataAnnotations;
using System.Web;
using System.ComponentModel;

namespace BankApp.Models
{
    public class Accounts
    {
        [Key]

        [Required]
        public Guid CustomerID { get; set; }


        [Required(ErrorMessage = "A FirstName is Required")]
        [RegularExpression("^[a-zA-Z ]*$")]
        public string FirstName { get; set; }


        [Required(ErrorMessage = "A LastName is Required")]
        [RegularExpression("^[a-zA-Z ]*$")]
        public string LastName { get; set; }


        [Required(ErrorMessage ="Address Must be Entered")]
        public string Address1 { get; set; }


        [Required(ErrorMessage = "Address Must be Entered")]
        public string? Address2 { get; set; }


        [Required(ErrorMessage ="City Must be Entered")]
        public string City { get; set; }


        [Required(ErrorMessage ="County Must be Enetered")]
        public string County { get; set; }


        [Required]
        [Range(7, 7, ErrorMessage = "Eircode Must Have Between 7 Letters")]
        public string Eircode { get; set; }


        [Required(ErrorMessage ="Phone Number must be Entered")]
        [DataType(DataType.PhoneNumber)]
        public string PhoneNumber { get; set; }


        [Required(ErrorMessage ="Email Must be Entered")]
        [RegularExpression("^[\\w-\\.]+@([\\w-]+\\.)+[\\w-]{2,4}$")]
        public string Email { get; set; }


        [Required]
        public string Pin { get; set; }


        public List<Transaction> Transactions { get; set; }
        
        public string Status { get; set; }
    }
}
