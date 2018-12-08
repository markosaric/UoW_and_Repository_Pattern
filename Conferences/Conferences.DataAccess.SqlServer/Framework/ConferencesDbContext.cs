using System;
using Conferences.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Conferences.DataAccess.SqlServer
{
    public class ConferencesDbContext : DbContext
    {
        public DbSet<Products> Products { get; set; }

        private readonly IConfiguration _configuration;

        public ConferencesDbContext(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_configuration.GetConnectionString("SqlConnection"));
        }
    }
}
