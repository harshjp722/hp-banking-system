using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Loans.Api.Models.EntityConfigurations
{
    public class LoanDetailsConfigurations : IEntityTypeConfiguration<LoanDetails>
    {
        public void Configure(EntityTypeBuilder<LoanDetails> builder)
        {
            builder.ToTable("LoanDetails");

            builder.HasKey(ci => ci.Id);

            builder.Property(ci => ci.Id)
               .ForSqlServerUseSequenceHiLo("loan_details_hilo")
               .IsRequired();

            builder.HasOne(ci => ci.LoanTypes)
                .WithMany()
                .HasForeignKey(ci => ci.LoanTypeId)
                .IsRequired();

            builder.Property(cb => cb.LoanHolder)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(cb => cb.LoanBranch)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(cb => cb.LoanAmount)
                .IsRequired();

            builder.Property(cb => cb.StartDate)
                .IsRequired();

            builder.Property(cb => cb.IsActive)
                .HasDefaultValue(value: true);
        }
    }
}
