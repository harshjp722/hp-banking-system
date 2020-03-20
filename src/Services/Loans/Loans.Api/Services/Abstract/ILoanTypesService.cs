using Loans.Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Loans.Api.Services.Abstract
{
    public interface ILoanTypesService
    {
        Task<List<LoanTypes>> GetLoanTypes();

        Task<LoanTypes> GetLoanTypeById(int id);

        Task<bool> AddLoanType(LoanTypes loanTypes);

        Task<bool> UpdateLoanTypes(LoanTypes loanTypes);
    }
}
