using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagement.Domain.Models.Entities
{
    public class SkillModel : IEntityBase
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public ICollection<EmployeeSkillModel> EmployeeSkills { get; set; }
        public ICollection<ProjectSkillModel> ProjectSkills { get; set; }
    }
}