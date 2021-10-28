using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using VisitorManager.Infrastructure.DTO;

namespace VisitorManager.Infrastructure.Services
{
    public interface IUserService : IServiceMarker
    {
        Task<IEnumerable<UserDetailDto>> BrowserAsync(string name = null);
        Task<AuthDto> GetAsync(Guid id);
        Task DeleteAsync(Guid id);
    }
}
