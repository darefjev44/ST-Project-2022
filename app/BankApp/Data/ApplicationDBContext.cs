using BankApp.Models;
using Microsoft.EntityFrameworkCore;

namespace BankApp.Models.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        public DbSet<ApplicationUser> Accounts { set; get; }

        public DbSet<TransactionModel> Transactions { set; get; }
    }
}
