using System.Collections.Generic;
using EmployeeManagement.Domain.Models.Entities;
using Microsoft.AspNetCore.Http;

namespace EmployeeManagement.Domain.Services.Interfaces
{
    public interface IEmployeeService
    {
        IEnumerable<EmployeeModel> GetAllEmployees();
        EmployeeModel GetEmployeeById(int id);
        void UpdateEmployee(EmployeeModel emp);
        void DeleteEmployee(int id);
        void CreateEmployee(EmployeeModel emp);
    }
}