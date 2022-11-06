using BankApp.Models;
using Microsoft.EntityFrameworkCore;

namespace BankApp.Models.Data
{
    public class ApplicationDBContext : DbContext
    {
        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options) : base(options)
        {

        }

        public DbSet<BankAccount> BankAccounts { set; get; }


        public DbSet<Customer> Customers { set; get; }

        public DbSet<Transaction> Transactions { set; get; }
    }
}
