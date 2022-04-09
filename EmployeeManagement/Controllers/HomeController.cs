using EmployeeManagement.DTO;
using EmployeeManagement.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagement.Controllers
{
    [Route("api/employee")]
    [ApiController]
    public class HomeController : ControllerBase
    {
        private readonly DbEmployeeManagementContext dbEmployeeManagementContext;

        public HomeController(DbEmployeeManagementContext dbEmployeeManagementContext)
        {
            this.dbEmployeeManagementContext = dbEmployeeManagementContext;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Employee>> GetEmployees()
        {
            var employees = dbEmployeeManagementContext
                .Employees
                .ToList();

            return Ok(employees);
        }

        [HttpGet("{id}")]
        public ActionResult<Employee> GetEmployee([FromRoute] int id)
        {
            var employee = dbEmployeeManagementContext
                .Employees
                .FirstOrDefault(e => e.UserId == id);

            if(employee is null)
            {
                return NotFound("This employee is not exist");
            }else
            {
                return Ok(employee);
            }
        }
    }
}
