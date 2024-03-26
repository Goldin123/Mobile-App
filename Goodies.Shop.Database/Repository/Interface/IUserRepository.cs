using Goodies.Shop.Database.Entities;
using Goodies.Shop.Model.ApiRequest;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Goodies.Shop.Database.Repository.Interface
{
    public interface IUserRepository
    {
        Task<List<User>> GetUsersAsync();
        Task<User> AddCustomerUserAsync(AddNewUserRequest addNewUserRequest);
    }
}
