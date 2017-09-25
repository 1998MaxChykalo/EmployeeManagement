using System;
using EmployeeManagement.Domain.Models.Entities;
using EmployeeManagement.Infrastructure;
using EmployeeManagement.Infrastructure.Repositories;
using EmployeeManagement.Infrastructure.Sql;
using EmployeeManagement.Infrastructure.Sql.Repositories;
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

        private IRepository<SkillModel> _skillRepository;
        private IRepository<EmployeeModel> _employeeRepository;
        private IRepository<EmployeeSkillModel> _employeeSkillRepository;
        private IRepository<EmployeeProjectModel> _employeeProjectRepository;
        private IRepository<ProjectModel> _projectRepository;
        private IRepository<ProjectSkillModel> _projectSkillRepository;


        public IRepository<SkillModel> SkillRepository => _skillRepository ??
                                                          (_skillRepository = new SkillRepository(_context));

        public IRepository<EmployeeModel> EmployeeRepository => _employeeRepository ??
                                                                 (_employeeRepository = new EmployeeRepository(_context));

        public IRepository<ProjectModel> ProjectRepository => _projectRepository ??
                                                               (_projectRepository = new ProjectRepository(_context));

        public IRepository<EmployeeSkillModel> EmployeeSkillRepository => _employeeSkillRepository ??
                                                                           (_employeeSkillRepository =
                                                                               new EmployeeSkillRepository(_context));

        public IRepository<EmployeeProjectModel> EmployeeProjectRepository => _employeeProjectRepository ??
                                                                               (_employeeProjectRepository =
                                                                                   new EmployeeProjectRepository(_context));

        public IRepository<ProjectSkillModel> ProjectSkillRepository => _projectSkillRepository ??
                                                                         (_projectSkillRepository =
                                                                             new ProjectSkillRepository(_context));

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