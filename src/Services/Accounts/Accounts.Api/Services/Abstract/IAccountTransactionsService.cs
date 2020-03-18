using Accounts.Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Accounts.Api.Services.Abstract
{
    public interface IAccountTransactionsService
    {
        Task<List<AccountTransactions>> GetAccountTransactions();

        Task<AccountTransactions> GetAccountTransactionsById(int id);

        Task<bool> AddAccountTransactions(AccountTransactions accountTransactions);

        Task<bool> UpdateAccountTransactions(AccountTransactions accountTransactions);
    }
}
