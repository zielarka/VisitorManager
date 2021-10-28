using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using VisitorManager.Core.Domain;

namespace VisitorManager.Core.Repository
{
    public interface IAuthRepository : IRepositoryMarker
    {
        Task<User> Login(string username, string password);
        Task Register(User @user);
    }
}
