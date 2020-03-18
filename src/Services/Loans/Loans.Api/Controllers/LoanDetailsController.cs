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
    public class LoanDetailsController : ControllerBase
    {
        private readonly ILoanDetailsService _accountDetailsService;
        public LoanDetailsController(ILoanDetailsService accountDetailsService)
        {
            _accountDetailsService = accountDetailsService ?? throw new ArgumentNullException(nameof(accountDetailsService));
        }

        /// <summary>
        /// Get Loans
        /// </summary>
        /// <returns>List of Loans</returns>
        [HttpGet]
        [Route("account-details")]
        public async Task<IActionResult> GetLoanDetails()
        {
            try
            {
                var response = await _accountDetailsService.GetLoanDetails();
                return Ok(response);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex);
                // throw; // Add logger and exception filter to remove try catch
            }
        }

        /// <summary>
        /// Get Loan Details
        /// </summary>
        /// <param name="id">Loan Id</param>
        /// <returns>Details of Loan</returns>
        [HttpGet]
        [Route("account-details/{id:int}")]
        public async Task<IActionResult> GetLoanDetailsById(int id)
        {
            try
            {
                var response = await _accountDetailsService.GetLoanDetailsById(id);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex);
                // throw; // Add logger and exception filter to remove try catch
            }
        }

        /// <summary>
        /// Add Loan Details
        /// </summary>
        /// <param name="accountDetailsRequest">Add Loan details</param>
        /// <returns>Response of success or failure</returns>
        [HttpPost]
        [Route("account-details/add")]
        public async Task<IActionResult> AddLoanDetails([FromBody]LoanDetails accountDetailsRequest)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                var accountDetails = new LoanDetails
                {
                    LoanTypeId = accountDetailsRequest.LoanTypeId,
                    LoanHolder = accountDetailsRequest.LoanHolder,
                    LoanBranch = accountDetailsRequest.LoanBranch,
                    LoanAmount = accountDetailsRequest.LoanAmount,
                    StartDate = accountDetailsRequest.StartDate
                };
                var response = await _accountDetailsService.AddLoanDetails(accountDetails);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex);
                // throw; // Add logger and exception filter to remove try catch
            }

        }

        /// <summary>
        /// Update Loan Details
        /// </summary>
        /// <param name="accountDetailsRequest">Update Loan Details</param>
        /// <returns>Response of success or failure</returns>
        [HttpPut]
        [Route("account-details/edit")]
        public async Task<IActionResult> UpdateLoanDetails([FromBody]LoanDetails accountDetailsRequest)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                var accountDetails = await _accountDetailsService.GetLoanDetailsById(accountDetailsRequest.Id);
                accountDetails.LoanHolder = accountDetailsRequest.LoanHolder;
                accountDetails.LoanBranch = accountDetailsRequest.LoanBranch;
                accountDetails.LoanAmount = accountDetailsRequest.LoanAmount;
                accountDetails.StartDate = accountDetailsRequest.StartDate;
                accountDetails.IsActive = accountDetailsRequest.IsActive;
                var response = await _accountDetailsService.UpdateLoanDetails(accountDetails);
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