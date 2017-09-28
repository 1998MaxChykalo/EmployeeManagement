using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using EmployeeManagement.Domain.Models.Entities;
using EmployeeManagement.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;

namespace EmployeeManagement.Infrastructure.Sql.Repositories
{
    public class ProjectRepository : IRepository<ProjectModel>
    {
        private EmployeeManagementDbContext _context;

        public ProjectRepository(EmployeeManagementDbContext context)
        {
            _context = context;
        }
        public IEnumerable<ProjectModel> GetAll()
        {
            var projectEntities = _context.Project.Include(pr => pr.EmployeeProjects)
                                                        .ThenInclude(emPr => emPr.Employee)
                                                    .Include(pr => pr.ProjectSkills)
                                                        .ThenInclude(prSk => prSk.Skill)
                                                    .ToList();
            var projectModels = Mapper.Map<List<Project>, List<ProjectModel>>(projectEntities);
            return projectModels;
        }

        public ProjectModel GetById(object id)
        {
            var projectEntity = _context.Project.Include(pr => pr.EmployeeProjects)
                                                        .ThenInclude(emPr => emPr.Employee)
                                                    .Include(pr => pr.ProjectSkills)
                                                        .ThenInclude(prSk => prSk.Skill)
                                                    .FirstOrDefault(e => e.Id == (int)id);
            var projectModels = Mapper.Map<Project, ProjectModel>(projectEntity);
            return projectModels;
        }

        public void Create(ProjectModel projectsModel)
        {
            var projectEntity = Mapper.Map<ProjectModel, Project>(projectsModel);
            _context.Project.Add(projectEntity);
        }

        public void Update(ProjectModel projectModel)
        {
            var projectEntity = Mapper.Map<ProjectModel, Project>(projectModel);
            _context.Entry(projectEntity).State = EntityState.Modified;
        }

        public void Delete(object id)
        {
            var projects = _context.Project.Find(id);
            if (projects != null)
                _context.Project.Remove(projects);
        }
    }
}