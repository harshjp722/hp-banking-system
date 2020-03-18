using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Loans.Api.Models
{
    public class LoansContextSeed
    {
        public async Task SeedAsync(LoansContext context, IHostingEnvironment env)
        {
            var contentRootPath = env.ContentRootPath;
            var picturePath = env.WebRootPath;

            if (!context.LoanType.Any())
            {
                await context.LoanType.AddRangeAsync(GetPreconfiguredLoanTypes());
                await context.SaveChangesAsync();
            }
        }

        private IEnumerable<LoanTypes> GetPreconfiguredLoanTypes()
        {
            return new List<LoanTypes>()
            {
                new LoanTypes() { Type = "HL", Description="Home Loan"},
                new LoanTypes() { Type = "BL" }
            };
        }
    }
}
