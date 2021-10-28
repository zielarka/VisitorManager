using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using VisitorManager.Infrastructure.DTO;

namespace VisitorManager.Infrastructure.Services
{
    public interface IAuthService : IServiceMarker
    {
        Task<AuthDto> Login(string username, string password);
        Task Register(Guid id, string username, string password);
    }
}
