using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Loans.Api.Models.EntityConfigurations
{
    public class LoanTransactionsConfigurations : IEntityTypeConfiguration<LoanTransactions>
    {
        public void Configure(EntityTypeBuilder<LoanTransactions> builder)
        {
            builder.ToTable("LoanTransactions");

            builder.HasKey(ci => ci.Id);

            builder.Property(ci => ci.Id)
               .ForSqlServerUseSequenceHiLo("loan_transactions_hilo")
               .IsRequired();

            builder.HasOne(ci => ci.LoanDetails)
                .WithMany()
                .HasForeignKey(ci => ci.LoanId)
                .IsRequired();

            builder.Property(cb => cb.TransactionAmount)
                .IsRequired();

            builder.Property(cb => cb.TransactionType)
                .IsRequired();

            builder.Property(cb => cb.TransactionDate)
                .IsRequired();

        }
    }
}
