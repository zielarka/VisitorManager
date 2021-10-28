using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System;
using VisitorManager.Core.Config;
using VisitorManager.Persistence.Migrations.Configurtion;

namespace VisitorManager.Persistence.Migrations
{
    public class DbContextFactory : IDesignTimeDbContextFactory<DataContext_Sqlite>
    {
        DataContext_Sqlite IDesignTimeDbContextFactory<DataContext_Sqlite>.CreateDbContext(string[] args)
        {
            var builder = new DbContextOptionsBuilder<DataContext_Sqlite>();
            builder.UseSqlite(Constants.ConnectionString);
            return new DataContext_Sqlite(builder.Options);
        }
    }
}
