using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Accounts.Api.Models.EntityConfigurations
{
    public class AccountDetailsConfigurations : IEntityTypeConfiguration<AccountDetails>
    {
        public void Configure(EntityTypeBuilder<AccountDetails> builder)
        {
            builder.ToTable("AccountDetails");

            builder.HasKey(ci => ci.Id);

            builder.Property(ci => ci.Id)
               .ForSqlServerUseSequenceHiLo("account_details_hilo")
               .IsRequired();

            builder.HasOne(ci => ci.AccountTypes)
                .WithMany()
                .HasForeignKey(ci => ci.AccountTypeId)
                .IsRequired();

            builder.Property(cb => cb.AccountHolder)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(cb => cb.AccountBranch)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(cb => cb.AccountBalance)
                .IsRequired();

            builder.Property(cb => cb.StartDate)
                .IsRequired();

            builder.Property(cb => cb.IsActive)
                .HasDefaultValue(value: true);
        }
    }
}
