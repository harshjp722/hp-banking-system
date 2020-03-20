using Loans.Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Loans.Api.Services.Abstract
{
    public interface ILoanTransactionsService
    {
        Task<List<LoanTransactions>> GetLoanTransactions();

        Task<LoanTransactions> GetLoanTransactionsById(int id);

        Task<bool> AddLoanTransactions(LoanTransactions loanTransactions);

        Task<bool> UpdateLoanTransactions(LoanTransactions loanTransactions);
    }
}
