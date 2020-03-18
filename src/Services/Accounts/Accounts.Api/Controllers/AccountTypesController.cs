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
    public class AccountTypesController : ControllerBase
    {
        private readonly IAccountTypesService _accountTypesService;
        /// <summary>
        /// 
        /// </summary>
        /// <param name="accountTypesService"></param>
        public AccountTypesController(IAccountTypesService accountTypesService)
        {
            _accountTypesService = accountTypesService ?? throw new ArgumentNullException(nameof(accountTypesService));
        }

        /// <summary>
        /// Get Account Types
        /// </summary>
        /// <returns>List of Account Types</returns>
        [HttpGet]
        [Route("account-types")]
        public async Task<IActionResult> GetAccountTypes()
        {
            try
            {
                var response = await _accountTypesService.GetAccountTypes();
                return Ok(response);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex);
                // throw; // Add logger and exception filter to remove try catch
            }
        }

        /// <summary>
        /// Get Account Type Details
        /// </summary>
        /// <param name="id">Account Type Id</param>
        /// <returns>Details of Account Type</returns>
        [HttpGet]
        [Route("account-types/{id:int}")]
        public async Task<IActionResult> GetAccountTypesById(int id)
        {
            try
            {
                var response = await _accountTypesService.GetAccountTypeById(id);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex);
                // throw; // Add logger and exception filter to remove try catch
            }
        }

        /// <summary>
        /// Add Account Type Details
        /// </summary>
        /// <param name="accountTypesRequest">Add Account Type details</param>
        /// <returns>Response of success or failure</returns>
        [HttpPost]
        [Route("account-types/add")]
        public async Task<IActionResult> AddAccountTypes([FromBody]AccountTypes accountTypesRequest)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                var accountTypes = new AccountTypes
                {
                    Type = accountTypesRequest.Type,
                    Description = accountTypesRequest.Description
                };
                var response = await _accountTypesService.AddAccountType(accountTypes);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex);
                // throw; // Add logger and exception filter to remove try catch
            }

        }

        /// <summary>
        /// Update Account Type Details
        /// </summary>
        /// <param name="accountTypesRequest">Update Account Type Details</param>
        /// <returns>Response of success or failure</returns>
        [HttpPut]
        [Route("account-types/edit")]
        public async Task<IActionResult> UpdateAccountTypes([FromBody]AccountTypes accountTypesRequest)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                var accountTypes = await _accountTypesService.GetAccountTypeById(accountTypesRequest.Id);
                accountTypes.Type = accountTypesRequest.Type;
                accountTypes.Description = accountTypesRequest.Description;
                var response = await _accountTypesService.UpdateAccountTypes(accountTypes);
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