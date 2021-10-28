using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VisitorManager.Core.Domain;
using VisitorManager.Core.Repository;
using VisitorManager.Persistence.Migrations;

namespace VisitorManager.Infrastructure.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly DataContext_Sqlite _context;
        public UserRepository(DataContext_Sqlite context)
        {
            _context = context;
        }

        public async Task<User> GetAsync(Guid id)
            => await Task.FromResult(_context.User.SingleOrDefault(x => x.Id == id));

        public async Task<User> GetAsync(String username)
         => await Task.FromResult(_context.User.SingleOrDefault(x => x.Username == username));

        public async Task<IEnumerable<User>> BrowserAsync(string name)
        {
            var users = _context.User.AsEnumerable();
            if (!string.IsNullOrWhiteSpace(name))
            {
                users = users.Where(x => x.Username.ToLowerInvariant().Contains(name.ToLowerInvariant()));
            }
            return await Task.FromResult(users);
        }
        public async Task DeleteAsync(User user)
        {
            _context.User.Remove(user);
            await _context.SaveChangesAsync();
            await Task.CompletedTask;
        }
    }
}
