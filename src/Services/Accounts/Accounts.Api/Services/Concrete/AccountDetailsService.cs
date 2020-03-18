using Accounts.Api.Models;
using Accounts.Api.Services.Abstract;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Accounts.Api.Services.Concrete
{
    /// <summary>
    /// 
    /// </summary>
    public class AccountDetailsService : IAccountDetailsService
    {
        private readonly AccountsContext _context;
        /// <summary>
        /// 
        /// </summary>
        /// <param name="context"></param>
        public AccountDetailsService(AccountsContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public async Task<List<AccountDetails>> GetAccountDetails()
        {
            return await _context.AccountDetail.Include(i => i.AccountTypes).OrderByDescending(o => o.StartDate).ToListAsync();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<AccountDetails> GetAccountDetailsById(int id)
        {
            return await _context.AccountDetail.Include(i => i.AccountTypes).FirstOrDefaultAsync(f => f.Id == id);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="accountDetails"></param>
        /// <returns></returns>
        public async Task<bool> AddAccountDetails(AccountDetails accountDetails)
        {
            try
            {
                _context.AccountDetail.Add(accountDetails);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {
                throw;
            }
           
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="accountDetails"></param>
        /// <returns></returns>
        public async Task<bool> UpdateAccountDetails(AccountDetails accountDetails)
        {
            try
            {
                _context.AccountDetail.Update(accountDetails);
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
