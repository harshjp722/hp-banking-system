using Loans.Api.Models;
using Loans.Api.Services.Abstract;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Loans.Api.Services.Concrete
{
    public class LoanTransactionsService : ILoanTransactionsService
    {
        private readonly LoansContext _context;
        public LoanTransactionsService(LoansContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<List<LoanTransactions>> GetLoanTransactions()
        {
            return await _context.LoanTransaction.Include(i => i.LoanDetails).OrderByDescending(o => o.TransactionDate).ToListAsync();
        }

        public async Task<LoanTransactions> GetLoanTransactionsById(int id)
        {
            return await _context.LoanTransaction.Include(i => i.LoanDetails).FirstOrDefaultAsync(f => f.Id == id);
        }

        public async Task<bool> AddLoanTransactions(LoanTransactions accountTransactions)
        {
            try
            {
                _context.LoanTransaction.Add(accountTransactions);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {
                throw;
            }

        }

        public async Task<bool> UpdateLoanTransactions(LoanTransactions accountTransactions)
        {
            try
            {
                _context.LoanTransaction.Update(accountTransactions);
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
