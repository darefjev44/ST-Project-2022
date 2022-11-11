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


        public DbSet<AccountModel> Customers { set; get; }

        public DbSet<TransactionModel> Transactions { set; get; }
    }
}
