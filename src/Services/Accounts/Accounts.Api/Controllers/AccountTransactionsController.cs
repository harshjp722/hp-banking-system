using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Accounts.Api.Models;
using Accounts.Api.Services.Abstract;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Accounts.Api.Controllers
{
    [Route("api/v1")]
    [ApiController]
    public class AccountTransactionsController : ControllerBase
    {
        private readonly IAccountTransactionsService _accountTransactionsService;
        /// <summary>
        /// 
        /// </summary>
        /// <param name="accountTransactionsService"></param>
        public AccountTransactionsController(IAccountTransactionsService accountTransactionsService)
        {
            _accountTransactionsService = accountTransactionsService ?? throw new ArgumentNullException(nameof(accountTransactionsService));
        }

        /// <summary>
        /// Get Account Transactions
        /// </summary>
        /// <returns>List of Account Transaction details</returns>
        [HttpGet]
        [Route("account-transactions")]
        public async Task<IActionResult> GetAccountTransactions()
        {
            try
            {
                var response = await _accountTransactionsService.GetAccountTransactions();
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
        /// <returns>Details of Account Transactions</returns>
        [HttpGet]
        [Route("account-transactions/{id:int}")]
        public async Task<IActionResult> GetAccountTransactionsById(int id)
        {
            try
            {
                var response = await _accountTransactionsService.GetAccountTransactionsById(id);
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
        public async Task<IActionResult> AddAccountTransactions([FromBody]AccountTransactions accountTransactionsRequest)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                var accountTransactions = new AccountTransactions
                {
                    AccountId = accountTransactionsRequest.AccountId,
                    TransactionAmount = accountTransactionsRequest.TransactionAmount,
                    TransactionType = accountTransactionsRequest.TransactionType,
                    TransactionDate = accountTransactionsRequest.TransactionDate
                };
                var response = await _accountTransactionsService.AddAccountTransactions(accountTransactions);
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
        public async Task<IActionResult> UpdateAccountTransactions([FromBody]AccountTransactions accountTransactionsRequest)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                var accountTransactions = await _accountTransactionsService.GetAccountTransactionsById(accountTransactionsRequest.Id);
                accountTransactions.TransactionType = accountTransactionsRequest.TransactionType;
                var response = await _accountTransactionsService.UpdateAccountTransactions(accountTransactions);
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