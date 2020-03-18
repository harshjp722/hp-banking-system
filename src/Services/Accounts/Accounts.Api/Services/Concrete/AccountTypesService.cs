using Accounts.Api.Models;
using Accounts.Api.Services.Abstract;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Accounts.Api.Services.Concrete
{
    public class AccountTypesService : IAccountTypesService
    {
        private readonly AccountsContext _context;
        public AccountTypesService(AccountsContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<List<AccountTypes>> GetAccountTypes()
        {
            return await _context.AccountType.OrderBy(o => o.Type).ToListAsync();
        }

        public async Task<AccountTypes> GetAccountTypeById(int id)
        {
            return await _context.AccountType.FirstOrDefaultAsync(f => f.Id == id);
        }

        public async Task<bool> AddAccountType(AccountTypes accountTypes)
        {
            try
            {
                _context.AccountType.Add(accountTypes);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<bool> UpdateAccountTypes(AccountTypes accountTypes)
        {
            try
            {
                _context.AccountType.Update(accountTypes);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
