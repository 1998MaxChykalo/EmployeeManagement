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
            var skills = _context.Skill.ToList();
            var skillsModels = Mapper.Map<List<Skill>, List<SkillModel>>(skills);
            return skillsModels;
        }

        public SkillModel GetById(object id)
        {
            var skill = _context.Skill.FirstOrDefault(e => e.Id == (int)id);
            var skillsModels = Mapper.Map<Skill, SkillModel>(skill);
            return skillsModels; 
        }

        public void Create(SkillModel skills)
        {
            Mapper.Initialize(cfg => cfg.CreateMap<SkillModel, Skill>());
            var skill= Mapper.Map<SkillModel, Skill>(skills);
            _context.Skill.Add(skill);
        }

        public void Update(SkillModel skills)
        {
            var skill = Mapper.Map<SkillModel, Skill>(skills);
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