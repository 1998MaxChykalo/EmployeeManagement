using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using EmployeeManagement.Domain.Models.Entities;
using EmployeeManagement.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;

namespace EmployeeManagement.Infrastructure.Sql.Repositories
{
    public class ProjectSkillRepository : IRepository<ProjectSkillModel>
    {
        private EmployeeManagementDbContext _context;

        public ProjectSkillRepository(EmployeeManagementDbContext context)
        {
            _context = context;
        }
        public IEnumerable<ProjectSkillModel> GetAll()
        {
            var projectSkillEntities = _context.ProjectSkill.ToList();
            var projectSkills = Mapper.Map<List<ProjectSkill>, List<ProjectSkillModel>>(projectSkillEntities);
            return projectSkills;
        }

        public ProjectSkillModel GetById(object id)
        {
            var projectSkillEntity = _context.ProjectSkill.FirstOrDefault(e => e.Id == (int)id);
            var projectSkills = Mapper.Map<ProjectSkill, ProjectSkillModel>(projectSkillEntity);
            return projectSkills;
        }

        public void Create(ProjectSkillModel projectSkillModel)
        {
            var projectSkillEntity = Mapper.Map<ProjectSkillModel, ProjectSkill>(projectSkillModel);
            _context.ProjectSkill.Add(projectSkillEntity);
        }

        public void Update(ProjectSkillModel projectSkillModel)
        {
            var projectSkillEntity = Mapper.Map<ProjectSkillModel, ProjectSkill>(projectSkillModel);
            _context.Entry(projectSkillEntity).State = EntityState.Modified;
        }

        public void Delete(object id)
        {
            var employeeSkills = _context.ProjectSkill.Find(id);
            if (employeeSkills != null)
                _context.ProjectSkill.Remove(employeeSkills);
        }
    }
}