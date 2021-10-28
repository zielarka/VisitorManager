using System;
using System.Collections.Generic;
using System.Text;

namespace VisitorManager.Core.Domain
{
    public class User :Entity
    {
        public string Username { get; protected set; }
        public byte[] PasswordHash { get; protected set; }
        public byte[] PasswordSalt { get; protected set; }
        public DateTime Created { get; protected set; }   
        public DateTime LastActive { get; protected set; }

        protected User()
        {
        }
        public User(Guid id, string username, byte[] passwordHash, byte[] passwordSalt)
        {
            Id = id;
            Username = username;
            PasswordHash = passwordHash;
            PasswordSalt = passwordSalt;
            Created = DateTime.UtcNow;
            LastActive = DateTime.UtcNow;
        }

    }
}
