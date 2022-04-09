using EmployeeManagement.DTO;
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
    }
}
