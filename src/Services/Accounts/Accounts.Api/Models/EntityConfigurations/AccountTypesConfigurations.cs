using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Accounts.Api.Models.EntityConfigurations
{
    public class AccountTypesConfigurations : IEntityTypeConfiguration<AccountTypes>
    {
        public void Configure(EntityTypeBuilder<AccountTypes> builder)
        {
            builder.ToTable("AccountTypes");

            builder.HasKey(ci => ci.Id);

            builder.Property(ci => ci.Id)
               .ForSqlServerUseSequenceHiLo("account_types_hilo")
               .IsRequired();

            builder.Property(cb => cb.Type)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(cb => cb.Description)
                .HasMaxLength(255);            
        }
    }
}
