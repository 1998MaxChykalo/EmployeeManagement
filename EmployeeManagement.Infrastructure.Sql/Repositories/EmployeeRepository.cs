using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using EmployeeManagement.Domain.Models.Entities;
using EmployeeManagement.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;

namespace EmployeeManagement.Infrastructure.Sql.Repositories
{
    public class EmployeeRepository : IRepository<EmployeeModel>
    {
        private EmployeeManagementDbContext _context;

        public EmployeeRepository(EmployeeManagementDbContext context)
        {
            _context = context;
        }
        public IEnumerable<EmployeeModel> GetAll()
        {
            var employeeEntities = _context.Employee.Include(emp => emp.EmployeeProjects)
                                                            .ThenInclude(emPr => emPr.Project)
                                                        .Include(emp => emp.EmployeeSkills)
                                                            .ThenInclude(emSk => emSk.Skill)
                                                        .ToList();
            var employeeModels = Mapper.Map<List<Employee>, List<EmployeeModel>>(employeeEntities);
            return employeeModels;
        }

        public EmployeeModel GetById(object id)
        {
            var employeeEntity = _context.Employee.Include(emp => emp.EmployeeProjects)
                                                            .ThenInclude(emPr => emPr.Project)
                                                        .Include(emp => emp.EmployeeSkills)
                                                            .ThenInclude(emSk => emSk.Skill)
                                                    .FirstOrDefault(e => e.Id == (int)id);
            var employeeModels = Mapper.Map<Employee, EmployeeModel>(employeeEntity);
            return employeeModels;
        }

        public void Create(EmployeeModel employeeModel)
        {
            var employeeEntity = Mapper.Map<EmployeeModel, Employee>(employeeModel);
            _context.Employee.Add(employeeEntity);
        }

        public void Update(EmployeeModel employeeModel)
        {
            var employeeEntity = Mapper.Map<EmployeeModel, Employee>(employeeModel);
            _context.Entry(employeeEntity).State = EntityState.Modified;
        }

        public void Delete(object id)
        {
            var employees = _context.Employee.Find(id);
            if (employees != null)
                _context.Employee.Remove(employees);
        }
    }
}