using System.Collections.Generic;
using System.IO;
using EmployeeManagement.Domain.Models.Entities;
using EmployeeManagement.Domain.Services.Interfaces;
using EmployeeManagement.Infrastructure.UnitOfWork;
using Microsoft.AspNetCore.Http;

namespace EmployeeManagement.Domain.Services.Employee
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IUnitOfWork _unitOfWork;

         public EmployeeService(IUnitOfWork unitOfWork)
         {
            _unitOfWork = unitOfWork;
         }

        public EmployeeModel GetEmployeeById(int id)
        {
            return _unitOfWork.EmployeeRepository.GetById(id);
        }
        
        public IEnumerable<EmployeeModel> GetAllEmployees()
        {
            return _unitOfWork.EmployeeRepository.GetAll();
        }

        public void CreateEmployee(EmployeeModel employeeModel)
        {
            _unitOfWork.EmployeeRepository.Create(employeeModel);
            _unitOfWork.SaveChanges();
        }

        public void UpdateEmployee(EmployeeModel employeeModel)
        {
            _unitOfWork.EmployeeRepository.Update(employeeModel);
            _unitOfWork.SaveChanges();
        }

        public void DeleteEmployee(int id)
        {
            _unitOfWork.EmployeeRepository.Delete(id);
            _unitOfWork.SaveChanges();
        }
    }
}