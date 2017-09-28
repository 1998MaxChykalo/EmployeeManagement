using System.Collections.Generic;
using EmployeeManagement.Domain.Models.Entities;

namespace EmployeeManagement.Domain.Services.Interfaces
{
    public interface ISkillService
    {
         IEnumerable<SkillModel> GetAllSkills();
        SkillModel GetSkillById(int id);
        void UpdateSkill(SkillModel skill);
        void DeleteSkill(int id);
        void CreateSkill(SkillModel skill);
    }
}