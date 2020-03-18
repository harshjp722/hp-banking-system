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
    public class AccountDetailsController : ControllerBase
    {
        private readonly IAccountDetailsService _accountDetailsService;
        /// <summary>
        /// 
        /// </summary>
        /// <param name="accountDetailsService"></param>
        public AccountDetailsController(IAccountDetailsService accountDetailsService)
        {
            _accountDetailsService = accountDetailsService ?? throw new ArgumentNullException(nameof(accountDetailsService));
        }

        /// <summary>
        /// Get Accounts
        /// </summary>
        /// <returns>List of Accounts</returns>
        [HttpGet]
        [Route("account-details")]
        public async Task<IActionResult> GetAccountDetails()
        {
            try
            {
                var response = await _accountDetailsService.GetAccountDetails();
                return Ok(response);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex);
                // throw; // Add logger and exception filter to remove try catch
            }
        }

        /// <summary>
        /// Get Account Details
        /// </summary>
        /// <param name="id">Account Id</param>
        /// <returns>Details of Account</returns>
        [HttpGet]
        [Route("account-details/{id:int}")]
        public async Task<IActionResult> GetAccountDetailsById(int id)
        {
            try
            {
                var response = await _accountDetailsService.GetAccountDetailsById(id);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex);
                // throw; // Add logger and exception filter to remove try catch
            }
        }

        /// <summary>
        /// Add Account Details
        /// </summary>
        /// <param name="accountDetailsRequest">Add Account details</param>
        /// <returns>Response of success or failure</returns>
        [HttpPost]
        [Route("account-details/add")]
        public async Task<IActionResult> AddAccountDetails([FromBody]AccountDetails accountDetailsRequest)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                var accountDetails = new AccountDetails
                {
                    AccountTypeId = accountDetailsRequest.AccountTypeId,
                    AccountHolder = accountDetailsRequest.AccountHolder,
                    AccountBranch = accountDetailsRequest.AccountBranch,
                    AccountBalance = accountDetailsRequest.AccountBalance,
                    StartDate = accountDetailsRequest.StartDate
                };
                var response = await _accountDetailsService.AddAccountDetails(accountDetails);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex);
                // throw; // Add logger and exception filter to remove try catch
            }

        }

        /// <summary>
        /// Update Account Details
        /// </summary>
        /// <param name="accountDetailsRequest">Update Account Details</param>
        /// <returns>Response of success or failure</returns>
        [HttpPut]
        [Route("account-details/edit")]
        public async Task<IActionResult> UpdateAccountDetails([FromBody]AccountDetails accountDetailsRequest)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                var accountDetails = await _accountDetailsService.GetAccountDetailsById(accountDetailsRequest.Id);
                accountDetails.AccountHolder = accountDetailsRequest.AccountHolder;
                accountDetails.AccountBranch = accountDetailsRequest.AccountBranch;
                accountDetails.AccountBalance = accountDetailsRequest.AccountBalance;
                accountDetails.StartDate = accountDetailsRequest.StartDate;
                accountDetails.IsActive = accountDetailsRequest.IsActive;
                var response = await _accountDetailsService.UpdateAccountDetails(accountDetails);
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