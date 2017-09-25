using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using EmployeeManagement.Domain.Models.Entities;
using EmployeeManagement.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;

namespace EmployeeManagement.Infrastructure.Sql.Repositories
{
    public class EmployeeSkillRepository : IRepository<EmployeeSkillModel>
    {
        private EmployeeManagementDbContext _context;

        public EmployeeSkillRepository(EmployeeManagementDbContext context)
        {
            _context = context;
        }
        public IEnumerable<EmployeeSkillModel> GetAll()
        {
            var employeeSkillEntities = _context.EmployeeSkill.ToList();
            var employeeSkillModels = Mapper.Map<List<EmployeeSkill>, List<EmployeeSkillModel>>(employeeSkillEntities);
            return employeeSkillModels;
        }

        public EmployeeSkillModel GetById(object id)
        {
            var employeeSkillEntity = _context.EmployeeSkill.FirstOrDefault(e => e.Id == (int)id);
            var employeeSkillModels = Mapper.Map<EmployeeSkill, EmployeeSkillModel>(employeeSkillEntity);
            return employeeSkillModels;
        }

        public void Create(EmployeeSkillModel employeeSkillModel)
        {
            var employeeSkillEntity = Mapper.Map<EmployeeSkillModel, EmployeeSkill>(employeeSkillModel);
            _context.EmployeeSkill.Add(employeeSkillEntity);
        }

        public void Update(EmployeeSkillModel employeeSkillModel)
        {
            var employeeSkillEntity = Mapper.Map<EmployeeSkillModel, EmployeeSkill>(employeeSkillModel);
            _context.Entry(employeeSkillEntity).State = EntityState.Modified;
        }

        public void Delete(object id)
        {
            var employeeSkills = _context.EmployeeSkill.Find(id);
            if (employeeSkills != null)
                _context.EmployeeSkill.Remove(employeeSkills);
        }
    }
}