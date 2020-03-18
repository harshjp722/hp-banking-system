using Accounts.Api.Models;
using Accounts.Api.Services.Abstract;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Accounts.Api.Services.Concrete
{
    public class AccountTransactionsService : IAccountTransactionsService
    {
        private readonly AccountsContext _context;
        public AccountTransactionsService(AccountsContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<List<AccountTransactions>> GetAccountTransactions()
        {
            return await _context.AccountTransaction.Include(i => i.AccountDetails).OrderByDescending(o => o.TransactionDate).ToListAsync();
        }

        public async Task<AccountTransactions> GetAccountTransactionsById(int id)
        {
            return await _context.AccountTransaction.Include(i => i.AccountDetails).FirstOrDefaultAsync(f => f.Id == id);
        }

        public async Task<bool> AddAccountTransactions(AccountTransactions accountTransactions)
        {
            try
            {
                _context.AccountTransaction.Add(accountTransactions);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {
                throw;
            }

        }

        public async Task<bool> UpdateAccountTransactions(AccountTransactions accountTransactions)
        {
            try
            {
                _context.AccountTransaction.Update(accountTransactions);
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
