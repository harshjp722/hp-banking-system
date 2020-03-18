using Accounts.Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Accounts.Api.Services.Abstract
{
    public interface IAccountDetailsService
    {
        Task<List<AccountDetails>> GetAccountDetails();

        Task<AccountDetails> GetAccountDetailsById(int id);

        Task<bool> AddAccountDetails(AccountDetails accountDetails);

        Task<bool> UpdateAccountDetails(AccountDetails accountDetails);
    }
}
