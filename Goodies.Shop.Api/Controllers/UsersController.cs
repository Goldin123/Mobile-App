using Azure;
using Goodies.Shop.Database.Entities;
using Goodies.Shop.Database.Repository.Interface;
using Goodies.Shop.Model.ApiRequest;
using Goodies.Shop.Model.ApiResponse;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Goodies.Shop.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly ILogger<UsersController> _logger;
        private readonly IUserRepository _userRepository;
        public UsersController(ILogger<UsersController> logger, IUserRepository userRepository) 
        {
            _logger = logger;
            _userRepository = userRepository;
        }
        [Route("GetUsers")]

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<ActionResult<IEnumerable<User>>> GetUsers()
        {
            try
            {
                var users = await _userRepository.GetUsersAsync();
                if (users?.Count > 0)
                    return Ok(users);
                else
                    return NoContent();
            }
            catch (Exception ex) 
            {
                return NoContent();
            }
        }
        [Route("AddCustomerUser")]
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<User>> AddCustomerUser([FromBody] AddNewUserRequest addNewUserRequest)
        {

            if (addNewUserRequest != null)
            {
                var addCustomer = await _userRepository.AddCustomerUserAsync(addNewUserRequest);
                return CreatedAtAction(nameof(AddCustomerUser), addCustomer);
            }
            else
            {
                _logger.LogError(string.Format("{0} - {1} - {2}.", DateTime.Now, nameof(AddCustomerUser), "Please enter valid details"));
                return StatusCode(StatusCodes.Status500InternalServerError, new Model.ApiResponse.Response { Status = "Error", Message = "Please enter valid details." });
            }
            
        }
    }
}
