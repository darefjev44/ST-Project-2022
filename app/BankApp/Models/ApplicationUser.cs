using System.ComponentModel.DataAnnotations;
using System.Web;
using System.ComponentModel;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;

namespace BankApp.Models
{
    public class ApplicationUser : IdentityUser<int>
    {
        public ApplicationUser()
        {
            this.Transactions = new List<TransactionModel>();
        }

        [ProtectedPersonalData]
        public List<TransactionModel> Transactions { get; set; }

        [DefaultValue(0.00)]
        [Column(TypeName = "decimal(10,2)")]
        [ProtectedPersonalData]
        public decimal Balance { get; set; }

        //Personal information
        [PersonalData]
        public string? FirstName { get; set; }

        [PersonalData]
        public string? LastName { get; set; }

        [ProtectedPersonalData]
        public string? Address1 { get; set; }

        [ProtectedPersonalData]
        public string? Address2 { get; set; }

        [ProtectedPersonalData]
        public string? City { get; set; }

        [ProtectedPersonalData]
        public string? County { get; set; }

        [ProtectedPersonalData]
        public string? Eircode { get; set; }
    }
}
