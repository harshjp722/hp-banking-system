using Loans.Api.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Loans.Api.Services.Abstract
{
    public interface ILoanDetailsService
    {
        Task<List<LoanDetails>> GetLoanDetails();

        Task<LoanDetails> GetLoanDetailsById(int id);

        Task<bool> AddLoanDetails(LoanDetails loanDetails);

        Task<bool> UpdateLoanDetails(LoanDetails loanDetails);
    }
}
