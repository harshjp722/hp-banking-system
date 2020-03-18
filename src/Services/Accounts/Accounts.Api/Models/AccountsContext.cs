using Accounts.Api.Models.EntityConfigurations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Accounts.Api.Models
{
    public class AccountsContext : DbContext
    {
        public AccountsContext(DbContextOptions<AccountsContext> options) : base(options)
        {
        }
        public DbSet<AccountTypes> AccountType { get; set; }
        public DbSet<AccountDetails> AccountDetail { get; set; }
        public DbSet<AccountTransactions> AccountTransaction { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new AccountDetailsConfigurations());
            builder.ApplyConfiguration(new AccountTransactionsConfigurations());
            builder.ApplyConfiguration(new AccountTypesConfigurations());
        }
    }

    public class AccountsContextDesignFactory : IDesignTimeDbContextFactory<AccountsContext>
    {
        public AccountsContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<AccountsContext>()
                .UseSqlServer("Server=.;Initial Catalog=HpBankingSystem.Services.AccountsDb;Integrated Security=true");

            return new AccountsContext(optionsBuilder.Options);
        }
    }
}
