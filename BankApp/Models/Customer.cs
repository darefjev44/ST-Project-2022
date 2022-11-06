namespace BankApp.Models
{
    public class Customer
    {

        public Guid CustomerID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address1 { get; set; }
        public string? Address2 { get; set; }
        public string City { get; set; }
        public string County { get; set; }
        public string Eircode { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
    }
}
