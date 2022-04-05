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
        private string _connectionString = "Server=(localdb)\\mssqllocaldb; Database=EmployeeManagementt; Trusted_Connection=True;";

        public DbSet<Employee> Employees { get; set; }
        public DbSet<Boss> Bosses { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<User> Users { get; set;  }
        public DbSet<Specialization> Specializations { get; set; }
        public DbSet<LevelOfAdvance> LevelOfAdvances { get; set; }
        public DbSet<Company> Companies { get; set; }
        public DbSet<LevelSpecializationOfAdvance> LevelSpecializationOfAdvances { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Boss>()
                .HasOne(c => c.Company)
                .WithOne(b => b.Boss)
                .HasForeignKey<Company>(c => c.UserId);

            modelBuilder.Entity<LevelSpecializationOfAdvance>()
                .HasKey(ls => new { ls.SpecializationId, ls.LevelOfAdvanceId, ls.UserId});

            modelBuilder.Entity<LevelSpecializationOfAdvance>()
                .HasOne(ls => ls.LevelOfAdvance)
                .WithMany(l => l.LevelSpecializationOfAdvances)
                .HasForeignKey(ls => ls.LevelOfAdvanceId);

            modelBuilder.Entity<LevelSpecializationOfAdvance>()
                .HasOne(s => s.Specialization)
                .WithMany(l => l.LevelSpecializationOfAdvances)
                .HasForeignKey(s => s.SpecializationId);

            modelBuilder.Entity<LevelSpecializationOfAdvance>()
                .HasOne(e => e.Employee)
                .WithMany(l => l.LevelSpecializationOfAdvances)
                .HasForeignKey(e => e.UserId);

            modelBuilder.Entity<Boss>().ToTable("Bosses");
            modelBuilder.Entity<Employee>().ToTable("Employees");
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_connectionString);
        }
    }
}
