using System;
using System.Net.Http;
using EmployeeManagement.Domain.Models.Entities;
using EmployeeManagement.Domain.Services.Interfaces;
using EmployeeManagement.Infrastructure.UnitOfWork;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace EmployeeManagement.Web.Api
{
    [Route("api/employees")]
    public class EmployeesApiController : Controller
    {
        IEmployeeService _employeeService;
        ILogger _logger;

        public EmployeesApiController(IEmployeeService employeeService, ILoggerFactory loggerFactory)
        {
            _employeeService = employeeService;
            _logger = loggerFactory.CreateLogger(nameof(EmployeesApiController));
        }

        //GET api/employees
        [HttpGet]
        public IActionResult Employees()
        {
            try
            {
                var employees = _employeeService.GetAllEmployees();
                return Ok(employees);
            }
            catch (Exception exp)
            {
                _logger.LogError(exp.Message);
                return BadRequest();
            }
        }

        //POST api/employees
        [HttpPost]
        public IActionResult Employees(EmployeeModel employeeModel)
        {
            try
            {
               _employeeService.CreateEmployee(employeeModel);
                return Ok(new {message = "Success"});
            }
            catch(Exception exp)
            {
                _logger.LogError(exp.Message);
                return BadRequest(new { message = "result" });
            }
        }

        //GET api/employees/5
        [HttpGet("{id}", Name = "GetEmployee")]
        public IActionResult Employees(int id)
        {
            try
            {
                var employee = _employeeService.GetEmployeeById(id);
                return Ok(employee);
            }
            catch (System.Exception exp)
            {
                _logger.LogError(exp.Message);
                return BadRequest();
            }
        }

        //PUT api/employees/5
        [HttpPut("{id}")]
        public IActionResult UpdateEmployee(int id,[FromBody]EmployeeModel employee)
        {
            try
            {
                _employeeService.UpdateEmployee(employee);
                return Ok(new {message = "Success"});
            }
            catch (System.Exception exp)
            {
                _logger.LogError(exp.Message);
                return BadRequest( new { message = "Update failure"});
            }
        }

        //DELETE api/employees/5
        [HttpDelete("{id}")]
        public IActionResult DeleteEmployee(int id)
        {
            try
            {
                _employeeService.DeleteEmployee(id);
                return Ok(new {message = "Success Delete"});
            }
            catch (System.Exception exp)
            {
                _logger.LogError(exp.Message);
                return BadRequest(new { message = "Failed to delete" });
            }
        }
    }
}