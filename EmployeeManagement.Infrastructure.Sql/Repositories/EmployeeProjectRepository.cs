using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using AutoMapper;
using EmployeeManagement.Domain.Models.Entities;
using EmployeeManagement.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;

namespace EmployeeManagement.Infrastructure.Sql.Repositories
{
    public class EmployeeProjectRepository : IRepository<EmployeeProjectModel>
    {
        private EmployeeManagementDbContext _context;

        public EmployeeProjectRepository(EmployeeManagementDbContext context)
        {
            _context = context;
        }
        public IEnumerable<EmployeeProjectModel> GetAll()
        {
            var employeeProjectEntities = _context.EmployeeProject.ToList();
            var employeeProjects = Mapper.Map<List<EmployeeProject>, List<EmployeeProjectModel>>(employeeProjectEntities);
            return employeeProjects;
        }

        public EmployeeProjectModel GetById(object id)
        {
            var employeeProjectEntity = _context.EmployeeProject.FirstOrDefault(e => e.Id == (int)id);
            var employeeProjects = Mapper.Map<EmployeeProject, EmployeeProjectModel>(employeeProjectEntity);
            return employeeProjects;
        }

        public void Create(EmployeeProjectModel employeeProjectModel)
        {
            var employeeProjectEntity = Mapper.Map<EmployeeProjectModel, EmployeeProject>(employeeProjectModel);
            _context.EmployeeProject.Add(employeeProjectEntity);
        }

        public void Update(EmployeeProjectModel employeeProjectModel)
        {
            var employeeProjectEntity = Mapper.Map<EmployeeProjectModel, EmployeeProject>(employeeProjectModel);
            _context.Entry(employeeProjectEntity).State = EntityState.Modified;
        }

        public void Delete(object id)
        {
            var employeeproject = _context.EmployeeProject.Find(id);
            if (employeeproject != null)
                _context.EmployeeProject.Remove(employeeproject);
        }

        public async Task<IEnumerable<EmployeeProjectModel>> GetAllAsync()
        {
            var employeeProjectEntities = await _context.EmployeeProject.ToListAsync();
            var employeeProjects = Mapper.Map<List<EmployeeProject>, List<EmployeeProjectModel>>(employeeProjectEntities);
            return employeeProjects;         
        }

        public Task<EmployeeProjectModel> GetByIdAsync(object id)
        {
            throw new NotImplementedException();
        }

        public void CreateAsync(EmployeeProjectModel item)
        {
            throw new NotImplementedException();
        }

        public void UpdateAsync(EmployeeProjectModel item)
        {
            throw new NotImplementedException();
        }

        public void DeleteAsync(object id)
        {
            throw new NotImplementedException();
        }

        public void DeleteRange(object[] ids)
        {
            throw new NotImplementedException();
        }
    }
}