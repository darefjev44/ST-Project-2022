using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace BankApp.Models.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser, CustomRole, int>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        public virtual DbSet<TransactionModel> Transactions { set; get; }
    }
}
