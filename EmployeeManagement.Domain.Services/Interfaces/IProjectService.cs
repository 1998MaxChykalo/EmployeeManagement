using System.Collections.Generic;
using EmployeeManagement.Domain.Models.Entities;

namespace EmployeeManagement.Domain.Services.Interfaces
{
    public interface IProjectService
    {
        IEnumerable<ProjectModel> GetAllProjects();
        ProjectModel GetProjectById(int id);
        void UpdateProject(ProjectModel project);
        void DeleteProject(int id);
        void CreateProject(ProjectModel project);
    }
}