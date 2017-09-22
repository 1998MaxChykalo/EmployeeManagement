using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagement.Domain.Models.Entities
{
    public class ProjectSkillModel
    {
        public int Id { get; set; }
        public int ProjectId { get; set; }
        public int SkillId { get; set; }
        public int Rank { get; set; }

        public ProjectModel Project { get; set; }
        public SkillModel Skill { get; set; }
    }
}