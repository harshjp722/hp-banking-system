using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Accounts.Api.Models
{
    public class AccountsContextSeed
    {
        public async Task SeedAsync(AccountsContext context, IHostingEnvironment env)
        {
            var contentRootPath = env.ContentRootPath;
            var picturePath = env.WebRootPath;

            if (!context.AccountType.Any())
            {
                await context.AccountType.AddRangeAsync(GetPreconfiguredAccountTypes());
                await context.SaveChangesAsync();
            }
        }

        private IEnumerable<AccountTypes> GetPreconfiguredAccountTypes()
        {
            return new List<AccountTypes>()
            {
                new AccountTypes() { Type = "Savings", Description="Savings account with 6% interest rate per annum"},
                new AccountTypes() { Type = "Current" }
            };
        }
    }
}
