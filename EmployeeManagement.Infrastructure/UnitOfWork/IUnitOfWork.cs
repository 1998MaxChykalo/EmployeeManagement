using System;
using System.Collections.Generic;
using EmployeeManagement.Domain.Models.Entities;
using EmployeeManagement.Infrastructure.Repositories;
namespace EmployeeManagement.Infrastructure.UnitOfWork
{
    public interface IUnitOfWork : IDisposable
     
    {
        int SaveChanges();

        IRepository<SkillModel> SkillRepository { get; }
        IRepository<EmployeeModel> EmployeeRepository { get; }
        IRepository<ProjectModel> ProjectRepository { get; }
        IRepository<EmployeeSkillModel> EmployeeSkillRepository { get; }
        IRepository<EmployeeProjectModel> EmployeeProjectRepository { get; }
        IRepository<ProjectSkillModel> ProjectSkillRepository { get; }
    }
}