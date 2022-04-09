﻿using EmployeeManagement.DTO;
using EmployeeManagement.Models;
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

        public AccountService(DbEmployeeManagementContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public void RegisterBoss(RegisterBossDTO bossDTO)
        {
            var newBoss = new Boss()
            {
                UserName = bossDTO.UserName,
                Password = bossDTO.Password,
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
            dbContext.Bosses.Add(newBoss);
            dbContext.SaveChanges();
        }
        public void RegisterEmployee(RegisterEmployeeDTO employeeDTO)
        {
            var code = dbContext
                .Companies
                .FirstOrDefault(c => c.Code == employeeDTO.Code);

            if (code.Code == employeeDTO.Code)
            {
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
                dbContext.Employees.Add(newEmployee);
                dbContext.SaveChanges();
            }
        }
    }
}
