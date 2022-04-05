using EmployeeManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagement
{
    public class DbInitializer
    {
        private readonly DbEmployeeManagementContext context;

        public DbInitializer(DbEmployeeManagementContext context)
        {
            this.context = context;
        }

        public void Seed()
        {
            if (context.Database.CanConnect())
            {
                if (!context.Roles.Any())
                {
                    var roles = GetRoles();
                    context.Roles.AddRange(roles);
                    context.SaveChanges();
                }
                if (!context.Specializations.Any())
                {
                    var specialization = GetSpecializations();
                    context.AddRange(specialization);
                    context.SaveChanges();
                }
                if (!context.LevelOfAdvances.Any())
                {
                    var levelOfAdvances = GetLevelOfAdvances();
                    context.AddRange(levelOfAdvances);
                    context.SaveChanges();
                }
                if (!context.Users.Any())
                {
                    var users = GetUsers();
                    context.AddRange(users);
                    context.SaveChanges();
                }
            }
        }
        private IEnumerable<Role> GetRoles()
        {
            var roles = new List<Role>()
            {
                new Role()
                {
                    Name = "Employee"
                },
                new Role()
                {
                    Name = "Boss"
                },
                new Role()
                {
                    Name = "Admin"
                },
            };
            return roles;
        }
        private IEnumerable<Specialization> GetSpecializations()
        {
            var specializations = new List<Specialization>()
            {
                new Specialization()
                {
                    Name = "Electrician"
                },
                new Specialization()
                {
                    Name = "Painter"
                },
                new Specialization()
                {
                    Name = "Plasterer"
                },
            };
            return specializations;
        }
        private IEnumerable<LevelOfAdvance> GetLevelOfAdvances()
        {
            var levelOfAdvances = new List<LevelOfAdvance>()
            {
                new LevelOfAdvance()
                {
                    Name = "Basic level"
                },
                new LevelOfAdvance()
                {
                    Name = "Medium level"
                },
                new LevelOfAdvance()
                {
                    Name = "Expert Level"
                }
            };
            return levelOfAdvances;
        }
        private IEnumerable<User> GetUsers()
        {
            var users = new List<User>()
            {
                new User()
                {
                    UserName = "EmployeeTest",
                    Password = "employeeTest",
                    FirstName = "Janusz",
                    LastName = "Szewczyk",
                    DateOfBirth = DateTime.Parse("03-03-1996"),
                    RoleId = 1
                },
                new User()
                {
                    UserName = "BossTest",
                    Password = "test",
                    FirstName = "Adam",
                    LastName = "Nowak",
                    DateOfBirth = DateTime.Parse("03-03-1996"),
                    RoleId = 2
                },
                new User()
                {
                    UserName = "AdminTest",
                    Password = "testadmin",
                    FirstName = "Bartek",
                    LastName = "Nowakowski",
                    DateOfBirth = DateTime.Parse("03-03-1996"),
                    RoleId = 3
                },

            };
            return users;
        }
    }
}
