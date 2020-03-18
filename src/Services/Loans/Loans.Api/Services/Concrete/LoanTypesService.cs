using Loans.Api.Models;
using Loans.Api.Services.Abstract;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Loans.Api.Services.Concrete
{
    public class LoanTypesService : ILoanTypesService
    {
        private readonly LoansContext _context;
        public LoanTypesService(LoansContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<List<LoanTypes>> GetLoanTypes()
        {
            return await _context.LoanType.OrderBy(o => o.Type).ToListAsync();
        }

        public async Task<LoanTypes> GetLoanTypeById(int id)
        {
            return await _context.LoanType.FirstOrDefaultAsync(f => f.Id == id);
        }

        public async Task<bool> AddLoanType(LoanTypes accountTypes)
        {
            try
            {
                _context.LoanType.Add(accountTypes);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<bool> UpdateLoanTypes(LoanTypes accountTypes)
        {
            try
            {
                _context.LoanType.Update(accountTypes);
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
