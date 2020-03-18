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
    public class LoanTypesController : ControllerBase
    {
        private readonly ILoanTypesService _accountTypesService;
        public LoanTypesController(ILoanTypesService accountTypesService)
        {
            _accountTypesService = accountTypesService ?? throw new ArgumentNullException(nameof(accountTypesService));
        }

        /// <summary>
        /// Get Loan Types
        /// </summary>
        /// <returns>List of Loan Types</returns>
        [HttpGet]
        [Route("account-types")]
        public async Task<IActionResult> GetLoanTypes()
        {
            try
            {
                var response = await _accountTypesService.GetLoanTypes();
                return Ok(response);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex);
                // throw; // Add logger and exception filter to remove try catch
            }
        }

        /// <summary>
        /// Get Loan Type Details
        /// </summary>
        /// <param name="id">Loan Type Id</param>
        /// <returns>Details of Loan Type</returns>
        [HttpGet]
        [Route("account-types/{id:int}")]
        public async Task<IActionResult> GetLoanTypesById(int id)
        {
            try
            {
                var response = await _accountTypesService.GetLoanTypeById(id);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex);
                // throw; // Add logger and exception filter to remove try catch
            }
        }

        /// <summary>
        /// Add Loan Type Details
        /// </summary>
        /// <param name="accountTypesRequest">Add Loan Type details</param>
        /// <returns>Response of success or failure</returns>
        [HttpPost]
        [Route("account-types/add")]
        public async Task<IActionResult> AddLoanTypes([FromBody]LoanTypes accountTypesRequest)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                var accountTypes = new LoanTypes
                {
                    Type = accountTypesRequest.Type,
                    Description = accountTypesRequest.Description
                };
                var response = await _accountTypesService.AddLoanType(accountTypes);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex);
                // throw; // Add logger and exception filter to remove try catch
            }

        }

        /// <summary>
        /// Update Loan Type Details
        /// </summary>
        /// <param name="accountTypesRequest">Update Loan Type Details</param>
        /// <returns>Response of success or failure</returns>
        [HttpPut]
        [Route("account-types/edit")]
        public async Task<IActionResult> UpdateLoanTypes([FromBody]LoanTypes accountTypesRequest)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                var accountTypes = await _accountTypesService.GetLoanTypeById(accountTypesRequest.Id);
                accountTypes.Type = accountTypesRequest.Type;
                accountTypes.Description = accountTypesRequest.Description;
                var response = await _accountTypesService.UpdateLoanTypes(accountTypes);
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