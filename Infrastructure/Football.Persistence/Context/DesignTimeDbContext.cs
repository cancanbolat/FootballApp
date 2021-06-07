using Football.Infrastructure.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Football.Infrastructure.Persistence.Context
{
    public class DesignTimeDbContext : IDesignTimeDbContextFactory<FootballDbContext>
    {
        public FootballDbContext CreateDbContext(string[] args)
        {
            string connectionString = Environment.GetEnvironmentVariable("ConnectionString");
            
            var builder = new DbContextOptionsBuilder<FootballDbContext>();
            builder.UseNpgsql(connectionString);

            return new FootballDbContext(builder.Options);
        }
    }
}
