using System;
using EmployeeManagement.Domain.Models.Entities;
using EmployeeManagement.Infrastructure;
using EmployeeManagement.Infrastructure.Repositories;
using EmployeeManagement.Infrastructure.Sql;
using EmployeeManagement.Infrastructure.UnitOfWork;

namespace CompanySkills.Infrastructure.Sql
{
    public class UnitOfWork : IUnitOfWork
    {
        public UnitOfWork(EmployeeManagementDbContext context)
        {
            _context = context;
            AutoMapperConfig.Configure();
        }
        private readonly EmployeeManagementDbContext _context;
        private bool _disposed;

        private IRepository<SkillModel,Skill> _skillRepository;
        private IRepository<EmployeeModel,Employee> _employeeRepository;
        private IRepository<EmployeeSkillModel,EmployeeSkill> _employeeSkillRepository;
        private IRepository<EmployeeProjectModel,EmployeeProject> _employeeProjectRepository;
        private IRepository<ProjectModel,Project> _projectRepository;
        private IRepository<ProjectSkillModel,ProjectSkill> _projectSkillRepository;


        public IRepository<SkillModel,Skill> SkillRepository => _skillRepository ??
                                                          (_skillRepository = new Repository<SkillModel, Skill>(_context));

        public IRepository<EmployeeModel,Employee> EmployeeRepository => _employeeRepository ??
                                                                 (_employeeRepository = new Repository<EmployeeModel,Employee>(_context));

        public IRepository<ProjectModel,Project> ProjectRepository => _projectRepository ??
                                                               (_projectRepository = new Repository<ProjectModel,Project>(_context));

        public IRepository<EmployeeSkillModel,EmployeeSkill> EmployeeSkillRepository => _employeeSkillRepository ??
                                                                           (_employeeSkillRepository =
                                                                               new Repository<EmployeeSkillModel,EmployeeSkill>(_context));

        public IRepository<EmployeeProjectModel,EmployeeProject> EmployeeProjectRepository => _employeeProjectRepository ??
                                                                               (_employeeProjectRepository =
                                                                                   new Repository<EmployeeProjectModel,EmployeeProject>(_context));

        public IRepository<ProjectSkillModel,ProjectSkill> ProjectSkillRepository => _projectSkillRepository ??
                                                                         (_projectSkillRepository =
                                                                             new Repository<ProjectSkillModel,ProjectSkill>(_context));

        #region Dispose

        public virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
                _disposed = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
#endregion
        public int SaveChanges()
        {
            return _context.SaveChanges();
        }
    }
}