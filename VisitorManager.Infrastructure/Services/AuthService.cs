using AutoMapper.Configuration;
using Microsoft.Extensions.Options;

using System;
using System.Collections.Generic;

using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using VisitorManager.Core.Config;
using VisitorManager.Core.Domain;
using VisitorManager.Core.Repository;
using VisitorManager.Infrastructure.DTO;
using VisitorManager.Infrastructure.Extensions;

namespace VisitorManager.Infrastructure.Services
{
    public class AuthService : IAuthService
    {
        private readonly IAuthRepository _authRepository;
        private readonly IUserRepository _userRepository;
        private readonly IOptions<AppSettingsOptions> _appsettings;

        public AuthService(IAuthRepository authRepository, IUserRepository userRepository, IOptions<AppSettingsOptions> appsettings)
        {
            _authRepository = authRepository;
            _userRepository = userRepository;
            _appsettings = appsettings;
        }


        public async Task<AuthDto> Login(string username, string password)
        {
            AuthDto userDto = new AuthDto();
            var user = await _authRepository.LoginOrFailAsync(username.ToLower(), password);
       
            return userDto = new AuthDto()
            {
                token = RepositoryExtensions.CreateToken(user, _appsettings.Value.token, _appsettings.Value.expires),
            };
            
        }

        public async Task Register(Guid id, string username, string password)
        {
            id = Guid.NewGuid();
            byte[] passwordHash, passwordSalt;
            RepositoryExtensions.CreatePasswordHashSalt(password, out passwordHash, out passwordSalt);
            var user = await _userRepository.GetAsync(username);
            if (user != null)
            {
                throw new Exception($"User id: '{id}' already exists");
            }
            user = new User(id, username, passwordHash, passwordSalt);
            await _authRepository.Register(user);
        }
    }
}
