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
                if(!context.Bosses.Any())
                {
                    var bosses = GetBosses();
                    context.AddRange(bosses);
                    context.SaveChanges();
                }
                if (!context.Employees.Any())
                {
                    var employees = GetEmployees();
                    context.AddRange(employees);
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
        public IEnumerable<Boss> GetBosses()
        {
            var bosses = new List<Boss>()
            {
                new Boss()
                {
                    RoleId = 2,
                    UserName = "BossTest",
                    Password = "bossTest",
                    FirstName = "Bartek",
                    LastName = "Nowakowski",
                    DateOfBirth = DateTime.Parse("03-03-1996"),
                    UniqueCode = "test",
                    Company = new Company()
                    {
                        NIP = "PL2302313",
                        CompanyName = "NowaFirma",
                        Code = "kodzikdofirmy",
                    }
                },
                new Boss()
                {
                    UserName = "BossTest2",
                    Password = "test2",
                    FirstName = "Adam",
                    LastName = "Nowak",
                    DateOfBirth = DateTime.Parse("03-03-1998"),
                    RoleId = 2,
                    UniqueCode = "test2",
                    Company = new Company()
                    {
                        NIP = "PL3200014",
                        CompanyName = "uStefczyka",
                        Code = "stefczyk3",
                    }
                },
            };
            return bosses;
        }
        public IEnumerable<Employee> GetEmployees()
        {
            var employees = new List<Employee>()
            {
                new Employee()
                {
                    UserName = "EmployeeTest",
                    Password = "employeeTest",
                    FirstName = "Janusz",
                    LastName = "Szewczyk",
                    DateOfBirth = DateTime.Parse("03-03-1996"),
                    RoleId = 1,
                    PhoneNumber = 323432456,
                    CompanyId = 1,
                    LevelSpecializationOfAdvances = new List<LevelSpecializationOfAdvance>()
                    {
                        new LevelSpecializationOfAdvance()
                        {
                            LevelOfAdvanceId = 1,
                            SpecializationId = 1
                        },
                        new LevelSpecializationOfAdvance()
                        {
                            LevelOfAdvanceId = 3,
                            SpecializationId = 2
                        }
                    }
                }
            };
            return employees;
        }
    }
}
