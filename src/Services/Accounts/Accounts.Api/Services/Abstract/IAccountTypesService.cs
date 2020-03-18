using Accounts.Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Accounts.Api.Services.Abstract
{
    public interface IAccountTypesService
    {
        Task<List<AccountTypes>> GetAccountTypes();

        Task<AccountTypes> GetAccountTypeById(int id);

        Task<bool> AddAccountType(AccountTypes accountTypes);

        Task<bool> UpdateAccountTypes(AccountTypes accountTypes);
    }
}
