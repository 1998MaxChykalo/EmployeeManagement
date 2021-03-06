using System;
using System.Collections.Generic;

namespace EmployeeManagement.Infrastructure.Sql
{
    public class Project
    {
        public Project()
        {
            EmployeeProjects = new HashSet<EmployeeProject>();
            ProjectSkills = new HashSet<ProjectSkill>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime StartDateUtc { get; set; }
        public bool IsInDevelopment { get; set; }
        // public string User { get; set; }

        public virtual ICollection<EmployeeProject> EmployeeProjects { get; set; }
        public virtual ICollection<ProjectSkill> ProjectSkills { get; set; }
    }
}