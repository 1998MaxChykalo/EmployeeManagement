using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using EmployeeManagement.Domain.Models.Entities;
using EmployeeManagement.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;

namespace EmployeeManagement.Infrastructure.Sql.Repositories
{
    public class SkillRepository : IRepository<SkillModel>
    {
       private readonly EmployeeManagementDbContext _context;

        public SkillRepository(EmployeeManagementDbContext context)
        {
            _context = context;
        }

        public IEnumerable<SkillModel> GetAll()
        {
            var skills = _context.Skill.Include(sk => sk.EmployeeSkills)
                                            .ThenInclude(emSk => emSk.Employee)
                                        .Include(sk => sk.ProjectSkills)
                                            .ThenInclude(prSk => prSk.Project)
                                        .ToList();
            var skillsModels = Mapper.Map<List<Skill>, List<SkillModel>>(skills);
            return skillsModels;
        }

        public SkillModel GetById(object id)
        {
            var skill = _context.Skill.Include(sk => sk.EmployeeSkills)
                                            .ThenInclude(emSk => emSk.Employee)
                                        .Include(sk => sk.ProjectSkills)
                                            .ThenInclude(prSk => prSk.Project)
                                        .FirstOrDefault(e => e.Id == (int)id);
            var skillsModels = Mapper.Map<Skill, SkillModel>(skill);
            return skillsModels; 
        }

        public void Create(SkillModel skillModel)
        {
            var skill= Mapper.Map<SkillModel, Skill>(skillModel);
            _context.Skill.Add(skill);
        }

        public void Update(SkillModel skillModel)
        {
            var skill = Mapper.Map<SkillModel, Skill>(skillModel);
            _context.Entry(skill).State = EntityState.Modified;
        }

        public void Delete(object id)
        {
            Skill skill = _context.Skill.Find(id);
            if (skill != null)
                _context.Skill.Remove(skill);
        }

    }
}