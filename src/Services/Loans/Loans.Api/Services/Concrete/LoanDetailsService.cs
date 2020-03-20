using Loans.Api.Models;
using Loans.Api.Services.Abstract;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Loans.Api.Services.Concrete
{
    public class LoanDetailsService : ILoanDetailsService
    {
        private readonly LoansContext _context;
        public LoanDetailsService(LoansContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<List<LoanDetails>> GetLoanDetails()
        {
            return await _context.LoanDetail.Include(i => i.LoanTypes).OrderByDescending(o => o.StartDate).ToListAsync();
        }

        public async Task<LoanDetails> GetLoanDetailsById(int id)
        {
            return await _context.LoanDetail.Include(i => i.LoanTypes).FirstOrDefaultAsync(f => f.Id == id);
        }

        public async Task<bool> AddLoanDetails(LoanDetails loanDetails)
        {
            try
            {
                _context.LoanDetail.Add(loanDetails);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {
                throw;
            }
           
        }

        public async Task<bool> UpdateLoanDetails(LoanDetails loanDetails)
        {
            try
            {
                _context.LoanDetail.Update(loanDetails);
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
