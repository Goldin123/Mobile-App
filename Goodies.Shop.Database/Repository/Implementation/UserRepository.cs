using Goodies.Shop.Database.Context;
using Goodies.Shop.Database.Entities;
using Goodies.Shop.Database.Repository.Interface;
using Goodies.Shop.Model.ApiRequest;
using Goodies.Shop.Model.Constants;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Goodies.Shop.Database.Repository.Implementation
{
    public class UserRepository : IUserRepository
    {
        private readonly ILogger<UserRepository> _logger;
        private readonly GoodiesContext _goodiesContext;
        public UserRepository(ILogger<UserRepository> logger, GoodiesContext goodiesContext)
        {
            _logger = logger;
            _goodiesContext = goodiesContext;
        } 

        public async Task<List<User>> GetUsersAsync() 
        {
            try 
            {
                _logger.LogInformation(string.Format("{0} - {1} - {2}.", DateTime.Now, nameof(GetUsersAsync), "attempting to retrieve users"));
                return await _goodiesContext.User.ToListAsync();
            } 
            catch (Exception ex) 
            {
                _logger.LogError(string.Format("{0} - {1} - {2}.", DateTime.Now, nameof(GetUsersAsync), ex.Message));
                throw new ArgumentException(ex.Message);
            }    
        }

        public async Task<User> AddCustomerUserAsync(AddNewUserRequest addNewUserRequest) 
        {
            try 
            {
                _logger.LogInformation(string.Format("{0} - {1} - {2}.", DateTime.Now, nameof(AddCustomerUserAsync), "attempting to add new user"));
                var user = new User
                {
                    FirstName = addNewUserRequest.FirstName,
                    LastName = addNewUserRequest.LastName,
                    EmailAddress = addNewUserRequest.EmailAddress,
                    Password = addNewUserRequest.Password,
                    Cellphone = addNewUserRequest.Cellphone,
                    DateCreated = DateTime.Now,
                    UserTypeID = (int)Enums.UserType.CUSTOMER,
                    IsAdmin =   false,
                    IsApproved = false,
                };

                _goodiesContext.User.Add(user);
                await _goodiesContext.SaveChangesAsync();

                return user;
            }
            catch (Exception ex) 
            {
                _logger.LogError(string.Format("{0} - {1} - {2} {3}.", DateTime.Now, nameof(AddCustomerUserAsync), ex.Message,ex.InnerException?.Message));
                throw new ArgumentException(ex.Message);
            }
        }

    }
}
