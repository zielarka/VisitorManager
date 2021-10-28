using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using VisitorManager.Core.Domain;

namespace VisitorManager.Core.Repository
{
    public interface IUserRepository :IRepositoryMarker
    {
        Task<User> GetAsync(Guid id);
        Task<User> GetAsync(String username);
        Task<IEnumerable<User>> BrowserAsync(string name);
        Task DeleteAsync(User @user);

    }
}
