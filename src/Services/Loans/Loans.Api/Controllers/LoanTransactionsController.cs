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
        private readonly ILoanTransactionsService _accountTransactionsService;
        public LoanTransactionsController(ILoanTransactionsService accountTransactionsService)
        {
            _accountTransactionsService = accountTransactionsService ?? throw new ArgumentNullException(nameof(accountTransactionsService));
        }

        /// <summary>
        /// Get Loan Transactions
        /// </summary>
        /// <returns>List of Loan Transaction details</returns>
        [HttpGet]
        [Route("account-transactions")]
        public async Task<IActionResult> GetLoanTransactions()
        {
            try
            {
                var response = await _accountTransactionsService.GetLoanTransactions();
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
        [Route("account-transactions/{id:int}")]
        public async Task<IActionResult> GetLoanTransactionsById(int id)
        {
            try
            {
                var response = await _accountTransactionsService.GetLoanTransactionsById(id);
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
        /// <param name="accountTransactionsRequest">Add Transaction details</param>
        /// <returns>Response of success or failure</returns>
        [HttpPost]
        [Route("account-transactions/add")]
        public async Task<IActionResult> AddLoanTransactions([FromBody]LoanTransactions accountTransactionsRequest)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                var accountTransactions = new LoanTransactions
                {
                    LoanId = accountTransactionsRequest.LoanId,
                    TransactionAmount = accountTransactionsRequest.TransactionAmount,
                    TransactionType = accountTransactionsRequest.TransactionType,
                    TransactionDate = accountTransactionsRequest.TransactionDate
                };
                var response = await _accountTransactionsService.AddLoanTransactions(accountTransactions);
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
        /// <param name="accountTransactionsRequest">Update Transaction Details</param>
        /// <returns>Response of success or failure</returns>
        [HttpPut]
        [Route("account-transactions/edit")]
        public async Task<IActionResult> UpdateLoanTransactions([FromBody]LoanTransactions accountTransactionsRequest)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                var accountTransactions = await _accountTransactionsService.GetLoanTransactionsById(accountTransactionsRequest.Id);
                accountTransactions.TransactionType = accountTransactionsRequest.TransactionType;
                var response = await _accountTransactionsService.UpdateLoanTransactions(accountTransactions);
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