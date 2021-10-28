using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using VisitorManager.Core.Domain;
using VisitorManager.Core.Repository;

namespace VisitorManager.Infrastructure.Extensions
{
    public static class RepositoryExtensions
    {
        public static async Task<Store> GetOrFailAsync(this IStoreRepository repository, Guid id)
        {
            var store = await repository.GetAsync(id);
            if (store == null)
            {
                throw new Exception($"Store with id: '{id}' does not exist.");
            }

            return store;
        }

        public static async Task<Device> GetOrFailAsync(this IDeviceRepository repository, Guid id)
        {
            var device = await repository.GetAsync(id);
            if (device == null)
            {
                throw new Exception($"Device with id: '{id}' does not exist.");
            }

            return device;
        }

   

        public static async Task<User> DeleteOrFailAsync(this IUserRepository repository, Guid id)
        {
            var user = await repository.GetAsync(id);
            if (user == null)
            {
                throw new Exception($"User with id: '{id}' does not exist.");
            }

            return user;
        }

        public static async Task<User> LoginOrFailAsync(this IAuthRepository repository, string username, string password)
        {
            var user = await repository.Login(username.ToLower(), password);
            if (user == null)
            {
                throw new Exception($"User named: '{username}' does not exist.");
            }

            return user;
        }


        #region Token
        public static void CreatePasswordHashSalt(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            using (var hmac = new System.Security.Cryptography.HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
            }
        }

        public static bool VerifyPasswordHash(string password, byte[] passwordHash, byte[] passwordSalt)
        {
            using (var hmac = new System.Security.Cryptography.HMACSHA512(passwordSalt))
            {
                var computtetHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));

                for (int i = 0; i < computtetHash.Length; i++)
                {
                    if (computtetHash[i] != passwordHash[i])
                    {
                        return false;
                    }
                }
                return true;
            }
        }
        public static string CreateToken(User user, string uniqueToken, int expires)
        {
            SecurityTokenDescriptor tokenDecriptor = new SecurityTokenDescriptor();
            var claims = new[]
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(ClaimTypes.Name, user.Username)
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(uniqueToken));
            var cred = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);
            tokenDecriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.Now.AddHours(expires),
                SigningCredentials = cred
            };

            var tokenHandler = new JwtSecurityTokenHandler();
            var token = tokenHandler.CreateToken(tokenDecriptor);

            return tokenHandler.WriteToken(token);
        }

        #endregion

    }
}
