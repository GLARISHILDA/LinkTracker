using GlarisEngine.UserLinkTracker.Domain.Authentication;
using Insight.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GlarisEngine.UserLinkTracker.RepositoryInterface
{
    public interface IAuthenticationRepository
    {
        [Sql(@"SELECT  * FROM dbo.[User]")]
        Task<List<User>> GetAllUsersAsync();

        [Sql(@"[dbo].[P_UserCreate]")]
        Task<long> RegisterUserAsync(User user);

        [Sql(@"SELECT TOP 1 *  FROM [dbo].[User] 
                WHERE EmailAddress = @EmailAddress")]
        Task<User> GetUserDetailsAsync(string emailAddress);
    }
}
