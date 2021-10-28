using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using VisitorManager.Core.Domain;
using VisitorManager.Core.Repository;
using VisitorManager.Infrastructure.Extensions;
using VisitorManager.Persistence.Migrations;

namespace VisitorManager.Infrastructure.Repositories
{
    public class AuthRepository : IAuthRepository
    {
        private readonly DataContext_Sqlite _context;

        public AuthRepository(DataContext_Sqlite context)
        {
            _context = context;
        }

        public async Task<User> Login(string username, string password)
        {
            var user = await _context.User.FirstOrDefaultAsync(x => x.Username == username);

            if (user == null || !RepositoryExtensions.VerifyPasswordHash(password, user.PasswordHash, user.PasswordSalt)  )
                return null;

            return user;
        }

        public async Task Register(User user)
        {
            await _context.User.AddAsync(user);
            await _context.SaveChangesAsync();
            await Task.CompletedTask;
        }


    }
}
