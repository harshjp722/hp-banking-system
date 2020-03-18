using Loans.Api.Models.EntityConfigurations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Loans.Api.Models
{
    public class LoansContext : DbContext
    {
        public LoansContext(DbContextOptions<LoansContext> options) : base(options)
        {
        }
        public DbSet<LoanTypes> LoanType { get; set; }
        public DbSet<LoanDetails> LoanDetail { get; set; }
        public DbSet<LoanTransactions> LoanTransaction { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new LoanDetailsConfigurations());
            builder.ApplyConfiguration(new LoanTransactionsConfigurations());
            builder.ApplyConfiguration(new LoanTypesConfigurations());
        }
    }

    public class LoansContextDesignFactory : IDesignTimeDbContextFactory<LoansContext>
    {
        public LoansContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<LoansContext>()
                .UseSqlServer("Server=.;Initial Catalog=HpBankingSystem.Services.LoansDb;Integrated Security=true");

            return new LoansContext(optionsBuilder.Options);
        }
    }
}
