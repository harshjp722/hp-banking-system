using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Accounts.Api.Models.EntityConfigurations
{
    public class AccountTransactionsConfigurations : IEntityTypeConfiguration<AccountTransactions>
    {
        public void Configure(EntityTypeBuilder<AccountTransactions> builder)
        {
            builder.ToTable("AccountTransactions");

            builder.HasKey(ci => ci.Id);

            builder.Property(ci => ci.Id)
               .ForSqlServerUseSequenceHiLo("account_transactions_hilo")
               .IsRequired();

            builder.HasOne(ci => ci.AccountDetails)
                .WithMany()
                .HasForeignKey(ci => ci.AccountId)
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
