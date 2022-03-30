using EmployeeManagement.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagement
{
    public class DbEmployeeManagementContext: DbContext
    {
        private string _connectionString = "Server=(localdb)\\MSSQLLocalDB; Database=EmployeeManagement; Trusted_Connection=True;";

        public DbSet<Employee> Employees { get; set; }
        public DbSet<Boss> Bosses { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<User> Users { get; set;  }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_connectionString);
        }
    }
}
