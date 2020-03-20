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
        private readonly ILoanDetailsService _loanDetailsService;
        public LoanDetailsController(ILoanDetailsService loanDetailsService)
        {
            _loanDetailsService = loanDetailsService ?? throw new ArgumentNullException(nameof(loanDetailsService));
        }

        /// <summary>
        /// Get Loans
        /// </summary>
        /// <returns>List of Loans</returns>
        [HttpGet]
        [Route("loan-details")]
        public async Task<IActionResult> GetLoanDetails()
        {
            try
            {
                var response = await _loanDetailsService.GetLoanDetails();
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
        [Route("loan-details/{id:int}")]
        public async Task<IActionResult> GetLoanDetailsById(int id)
        {
            try
            {
                var response = await _loanDetailsService.GetLoanDetailsById(id);
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
        /// <param name="loanDetailsRequest">Add Loan details</param>
        /// <returns>Response of success or failure</returns>
        [HttpPost]
        [Route("loan-details/add")]
        public async Task<IActionResult> AddLoanDetails([FromBody]LoanDetails loanDetailsRequest)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                var loanDetails = new LoanDetails
                {
                    LoanTypeId = loanDetailsRequest.LoanTypeId,
                    LoanHolder = loanDetailsRequest.LoanHolder,
                    LoanBranch = loanDetailsRequest.LoanBranch,
                    LoanAmount = loanDetailsRequest.LoanAmount,
                    StartDate = loanDetailsRequest.StartDate
                };
                var response = await _loanDetailsService.AddLoanDetails(loanDetails);
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
        /// <param name="loanDetailsRequest">Update Loan Details</param>
        /// <returns>Response of success or failure</returns>
        [HttpPut]
        [Route("loan-details/edit")]
        public async Task<IActionResult> UpdateLoanDetails([FromBody]LoanDetails loanDetailsRequest)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                var loanDetails = await _loanDetailsService.GetLoanDetailsById(loanDetailsRequest.Id);
                loanDetails.LoanHolder = loanDetailsRequest.LoanHolder;
                loanDetails.LoanBranch = loanDetailsRequest.LoanBranch;
                loanDetails.LoanAmount = loanDetailsRequest.LoanAmount;
                loanDetails.StartDate = loanDetailsRequest.StartDate;
                loanDetails.IsActive = loanDetailsRequest.IsActive;
                var response = await _loanDetailsService.UpdateLoanDetails(loanDetails);
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