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
        private readonly ILoanTypesService _loanTypesService;
        public LoanTypesController(ILoanTypesService loanTypesService)
        {
            _loanTypesService = loanTypesService ?? throw new ArgumentNullException(nameof(loanTypesService));
        }

        /// <summary>
        /// Get Loan Types
        /// </summary>
        /// <returns>List of Loan Types</returns>
        [HttpGet]
        [Route("loan-types")]
        public async Task<IActionResult> GetLoanTypes()
        {
            try
            {
                var response = await _loanTypesService.GetLoanTypes();
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
        [Route("loan-types/{id:int}")]
        public async Task<IActionResult> GetLoanTypesById(int id)
        {
            try
            {
                var response = await _loanTypesService.GetLoanTypeById(id);
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
        /// <param name="loanTypesRequest">Add Loan Type details</param>
        /// <returns>Response of success or failure</returns>
        [HttpPost]
        [Route("loan-types/add")]
        public async Task<IActionResult> AddLoanTypes([FromBody]LoanTypes loanTypesRequest)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                var loanTypes = new LoanTypes
                {
                    Type = loanTypesRequest.Type,
                    Description = loanTypesRequest.Description
                };
                var response = await _loanTypesService.AddLoanType(loanTypes);
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
        /// <param name="loanTypesRequest">Update Loan Type Details</param>
        /// <returns>Response of success or failure</returns>
        [HttpPut]
        [Route("loan-types/edit")]
        public async Task<IActionResult> UpdateLoanTypes([FromBody]LoanTypes loanTypesRequest)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                var loanTypes = await _loanTypesService.GetLoanTypeById(loanTypesRequest.Id);
                loanTypes.Type = loanTypesRequest.Type;
                loanTypes.Description = loanTypesRequest.Description;
                var response = await _loanTypesService.UpdateLoanTypes(loanTypes);
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