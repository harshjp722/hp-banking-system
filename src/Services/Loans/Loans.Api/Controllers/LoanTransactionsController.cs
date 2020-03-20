using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Loans.Api.Models;
using Loans.Api.Services.Abstract;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Loans.Api.Controllers
{
    [Route("api/v1")]
    [ApiController]
    public class LoanTransactionsController : ControllerBase
    {
        private readonly ILoanTransactionsService _loanTransactionsService;
        public LoanTransactionsController(ILoanTransactionsService loanTransactionsService)
        {
            _loanTransactionsService = loanTransactionsService ?? throw new ArgumentNullException(nameof(loanTransactionsService));
        }

        /// <summary>
        /// Get Loan Transactions
        /// </summary>
        /// <returns>List of Loan Transaction details</returns>
        [HttpGet]
        [Route("loan-transactions")]
        public async Task<IActionResult> GetLoanTransactions()
        {
            try
            {
                var response = await _loanTransactionsService.GetLoanTransactions();
                return Ok(response);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex);
                // throw; // Add logger and exception filter to remove try catch
            }
        }

        /// <summary>
        /// Get Transaction Details
        /// </summary>
        /// <param name="id">Transaction Id</param>
        /// <returns>Details of Loan Transactions</returns>
        [HttpGet]
        [Route("loan-transactions/{id:int}")]
        public async Task<IActionResult> GetLoanTransactionsById(int id)
        {
            try
            {
                var response = await _loanTransactionsService.GetLoanTransactionsById(id);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex);
                // throw; // Add logger and exception filter to remove try catch
            }
        }

        /// <summary>
        /// Add Transaction Details
        /// </summary>
        /// <param name="loanTransactionsRequest">Add Transaction details</param>
        /// <returns>Response of success or failure</returns>
        [HttpPost]
        [Route("loan-transactions/add")]
        public async Task<IActionResult> AddLoanTransactions([FromBody]LoanTransactions loanTransactionsRequest)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                var loanTransactions = new LoanTransactions
                {
                    LoanId = loanTransactionsRequest.LoanId,
                    TransactionAmount = loanTransactionsRequest.TransactionAmount,
                    TransactionType = loanTransactionsRequest.TransactionType,
                    TransactionDate = loanTransactionsRequest.TransactionDate
                };
                var response = await _loanTransactionsService.AddLoanTransactions(loanTransactions);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex);
                // throw; // Add logger and exception filter to remove try catch
            }

        }

        /// <summary>
        /// Update Transaction Details
        /// </summary>
        /// <param name="loanTransactionsRequest">Update Transaction Details</param>
        /// <returns>Response of success or failure</returns>
        [HttpPut]
        [Route("loan-transactions/edit")]
        public async Task<IActionResult> UpdateLoanTransactions([FromBody]LoanTransactions loanTransactionsRequest)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                var loanTransactions = await _loanTransactionsService.GetLoanTransactionsById(loanTransactionsRequest.Id);
                loanTransactions.TransactionType = loanTransactionsRequest.TransactionType;
                var response = await _loanTransactionsService.UpdateLoanTransactions(loanTransactions);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex);
                // throw; // Add logger and exception filter to remove try catch
            }
        }
    }
}