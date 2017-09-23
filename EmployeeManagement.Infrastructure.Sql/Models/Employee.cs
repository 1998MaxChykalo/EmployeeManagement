using System.Collections.Generic;
using EmployeeManagement.Infrastructure;

namespace EmployeeManagement.Infrastructure.Sql
{
    public class Employee : IEntityBase
    {
        public Employee()
        {
            EmployeeProjects = new HashSet<EmployeeProject>();
            EmployeeSkills = new HashSet<EmployeeSkill>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string UserId { get; set; }
        public string Photo { get; set; }
        public bool IsAvailable { get; set; }
        public int Rank { get; set; }

        public virtual ICollection<EmployeeProject> EmployeeProjects { get; set; }
        public virtual ICollection<EmployeeSkill> EmployeeSkills { get; set; }
        // public virtual AspNetUsers User { get; set; }
    }
}