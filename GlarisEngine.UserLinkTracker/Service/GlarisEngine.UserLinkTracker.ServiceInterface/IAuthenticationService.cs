using GlarisEngine.UserLinkTracker.Domain.Authentication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GlarisEngine.UserLinkTracker.ServiceInterface
{
    public interface IAuthenticationService
    {
        Task<List<User>> GetAllUsersAsync();

        Task<long> RegisterUserAsync(User user);

        Task<User> GetUserDetailsAsync(string emailAddress);

        Task<UserAuthentication> ValidateLoginUserAsync(User user);

    }
}
