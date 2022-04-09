using AutoMapper;
using EmployeeManagement.DTO;
using EmployeeManagement.Models;
using EmployeeManagement.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagement.Controllers
{
    [Route("api/account")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IAccountService accountservice;

        public AccountController(IAccountService accountService)
        {
            this.accountservice = accountService;
        }

        [Route("register/boss")]
        [HttpPost]
        public ActionResult RegisterBoss([FromBody] RegisterBossDTO bossDTO)
        {
            accountservice.RegisterBoss(bossDTO);
            return Ok();
        }


        [Route("register/employee")]
        [HttpPost]
        public ActionResult RegisterEmployee([FromBody] RegisterEmployeeDTO employeeDTO)
        {
            accountservice.RegisterEmployee(employeeDTO);

            return Ok();
        }
    }
}
