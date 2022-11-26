using System.ComponentModel.DataAnnotations;
using System.Web;
using System.ComponentModel;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;
using BankApp.Models.Data;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using System.Xml.Linq;

namespace BankApp.Models
{
    public class CustomUserRole : IdentityUserRole<int> { }

    public class CustomRole : IdentityRole<int>
    {
        public CustomRole() { }
        public CustomRole(string name) { Name = name; }
    }
}
