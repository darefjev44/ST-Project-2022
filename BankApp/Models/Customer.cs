using System.ComponentModel.DataAnnotations;

namespace BankApp.Models
{
    public class Customer
    {
        [Key]
        public Guid CustomerID { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public string Address1 { get; set; }
        public string? Address2 { get; set; }
        [Required]
        public string City { get; set; }
        [Required]
        public string County { get; set; }
        [Required]
        public string Eircode { get; set; }
        [Required]
        public string PhoneNumber { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Pac { get; set; }
        [Required]
        public string Status { get; set; }
        public List<BankAccount>? BankAccounts { get; set; }
    }
}
