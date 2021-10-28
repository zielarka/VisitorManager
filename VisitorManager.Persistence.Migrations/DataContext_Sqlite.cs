using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using VisitorManager.Core.Config;
using VisitorManager.Core.Domain;
using VisitorManager.Core.Repository;
using VisitorManager.Persistence.Migrations.Configurtion;

namespace VisitorManager.Persistence.Migrations
{


    public class DataContext_Sqlite : DbContext,IRepositoryMarker
    {
        public DataContext_Sqlite(DbContextOptions<DataContext_Sqlite> options) : base(options) { }
        public DbSet<Store> Store { get; set; }
        public DbSet<User> User { get; set; }
        public DbSet<Device> Device { get; set; }
        public DbSet<Event> Event { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlite(Constants.ConnectionString);
            }
        }


    }
}
