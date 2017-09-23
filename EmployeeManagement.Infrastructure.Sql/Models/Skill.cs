using System.Collections.Generic;

namespace EmployeeManagement.Infrastructure.Sql
{
    public class Skill : IEntityBase
    {
        public Skill()
        {
            EmployeeSkills = new HashSet<EmployeeSkill>();
            ProjectSkills = new HashSet<ProjectSkill>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<EmployeeSkill> EmployeeSkills { get; set; }
        public virtual ICollection<ProjectSkill> ProjectSkills { get; set; }
    }
}