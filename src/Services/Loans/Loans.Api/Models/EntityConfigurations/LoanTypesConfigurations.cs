using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Loans.Api.Models.EntityConfigurations
{
    public class LoanTypesConfigurations : IEntityTypeConfiguration<LoanTypes>
    {
        public void Configure(EntityTypeBuilder<LoanTypes> builder)
        {
            builder.ToTable("LoanTypes");

            builder.HasKey(ci => ci.Id);

            builder.Property(ci => ci.Id)
               .ForSqlServerUseSequenceHiLo("loan_types_hilo")
               .IsRequired();

            builder.Property(cb => cb.Type)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(cb => cb.Description)
                .HasMaxLength(255);            
        }
    }
}
