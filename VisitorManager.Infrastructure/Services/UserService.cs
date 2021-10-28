using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using VisitorManager.Core.Repository;
using VisitorManager.Infrastructure.DTO;
using VisitorManager.Infrastructure.Extensions;

namespace VisitorManager.Infrastructure.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userepository;
        private readonly IMapper _mapper;

        public UserService(IUserRepository storeRepository, IMapper mapper)
        {
            _userepository = storeRepository;
            _mapper = mapper;
        }

        public async Task<AuthDto> GetAsync(Guid id)
        {
            var user = await _userepository.GetAsync(id);
            return _mapper.Map<AuthDto>(user);
        }

        public async Task<IEnumerable<UserDetailDto>> BrowserAsync(string name = null)
        {
            var users = await _userepository.BrowserAsync(name);
            return _mapper.Map<IEnumerable<UserDetailDto>>(users);
        }
        public async Task DeleteAsync(Guid id)
        {
            var store = await _userepository.DeleteOrFailAsync(id);
            await _userepository.DeleteAsync(store);
        }
    }
}
