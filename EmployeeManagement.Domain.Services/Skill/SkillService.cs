using System.Collections.Generic;
using EmployeeManagement.Domain.Models.Entities;
using EmployeeManagement.Domain.Services.Interfaces;
using EmployeeManagement.Infrastructure.UnitOfWork;

namespace EmployeeManagement.Domain.Services.Skill
{
    public class SkillService : ISkillService
    {
        private readonly IUnitOfWork _unitOfWork;

         public SkillService(IUnitOfWork unitOfWork)
         {
            _unitOfWork = unitOfWork;
         }
        public void CreateSkill(SkillModel skill)
        {
            _unitOfWork.SkillRepository.Create(skill);
        }

        public void DeleteSkill(int id)
        {
            _unitOfWork.SkillRepository.Delete(id);
        }

        public IEnumerable<SkillModel> GetAllSkills()
        {
            var skills = _unitOfWork.SkillRepository.GetAll();
            return skills;
        }

        public SkillModel GetSkillById(int id)
        {
            var skill = _unitOfWork.SkillRepository.GetById(id);
            return skill;
        }

        public void UpdateSkill(SkillModel skill)
        {
            _unitOfWork.SkillRepository.Update(skill);
        }
    }
}