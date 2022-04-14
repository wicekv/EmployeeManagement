using EmployeeManagement.DTO;
using EmployeeManagement.Exceptions;
using EmployeeManagement.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagement.Services
{
    public interface IAccountService
    {
        public void RegisterBoss(RegisterBossDTO bossDTO);
        public void RegisterEmployee(RegisterEmployeeDTO employeeDTO);
    }
    public class AccountService : IAccountService
    {
        private readonly DbEmployeeManagementContext dbContext;
        private readonly ILogger<AccountService> logger;
        private readonly IPasswordHasher<User> passwordHasher;
        public AccountService(DbEmployeeManagementContext dbContext, ILogger<AccountService> logger, IPasswordHasher<User> passwordHasher)
        {
            this.dbContext = dbContext;
            this.logger = logger;
            this.passwordHasher = passwordHasher;
        }
        public void RegisterBoss(RegisterBossDTO bossDTO)
        {
            var newBoss = new Boss()
            {
                UserName = bossDTO.UserName,
                FirstName = bossDTO.FirstName,
                LastName = bossDTO.LastName,
                DateOfBirth = bossDTO.DateOfBirth,
                RoleId = bossDTO.RoleId,
                UniqueCode = bossDTO.UniqueCode,
                Company = new Company()
                {
                    NIP = bossDTO.NIP,
                    CompanyName = bossDTO.CompanyName,
                    Code = bossDTO.Code
                }
            };
            var hashedPassword = passwordHasher.HashPassword(newBoss, bossDTO.Password);
            newBoss.Password = hashedPassword;

            dbContext.Bosses.Add(newBoss);
            dbContext.SaveChanges();
        }
        public void RegisterEmployee(RegisterEmployeeDTO employeeDTO)
        {
            var code = dbContext
                .Companies
                .FirstOrDefault(c => c.Code == employeeDTO.Code);

            if (code == null)
                throw new NotFoundException("Code not found");

                var newEmployee = new Employee()
                {
                    UserName = employeeDTO.UserName,
                    Password = employeeDTO.Password,
                    FirstName = employeeDTO.FirstName,
                    LastName = employeeDTO.LastName,
                    DateOfBirth = employeeDTO.DateOfBirth,
                    RoleId = employeeDTO.RoleId,
                    PhoneNumber = employeeDTO.PhoneNumber,
                    CompanyId = code.CompanyId
                };
            var hashedPassword = passwordHasher.HashPassword(newEmployee, employeeDTO.Password);
            newEmployee.Password = hashedPassword;

            dbContext.Employees.Add(newEmployee);
            dbContext.SaveChanges();
        }
    }
}
