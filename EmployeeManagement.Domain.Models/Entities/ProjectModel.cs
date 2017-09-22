using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagement.Domain.Models.Entities
{
    public class ProjectModel
    {

        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime StartDateUtc { get; set; }
        public bool Status { get; set; }
        public string User { get; set; }

        public ICollection<EmployeeProjectModel> EmployeeProjects { get; set; }
        public ICollection<ProjectSkillModel> ProjectSkills { get; set; }
    }
}