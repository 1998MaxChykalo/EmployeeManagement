using System.Collections.Generic;
using EmployeeManagement.Domain.Models.Entities;
using EmployeeManagement.Domain.Services.Interfaces;
using EmployeeManagement.Infrastructure.UnitOfWork;

namespace EmployeeManagement.Domain.Services.Project
{
    public class ProjectService : IProjectService
    {
        private readonly IUnitOfWork _unitOfWork;

         public ProjectService(IUnitOfWork unitOfWork)
         {
            _unitOfWork = unitOfWork;
         }

        public ProjectModel GetProjectById(int id)
        {
            return _unitOfWork.ProjectRepository.GetById(id);
        }
        
        public IEnumerable<ProjectModel> GetAllProjects()
        {
            return _unitOfWork.ProjectRepository.GetAll();
        }

        public void CreateProject(ProjectModel projectModel)
        {
            _unitOfWork.ProjectRepository.Create(projectModel);
            _unitOfWork.SaveChanges();
        }

        public void UpdateProject(ProjectModel projectModel)
        {
            _unitOfWork.ProjectRepository.Update(projectModel);
            _unitOfWork.SaveChanges();
        }

        public void DeleteProject(int id)
        {
            _unitOfWork.ProjectRepository.Delete(id);
            _unitOfWork.SaveChanges();
        }
    }
}