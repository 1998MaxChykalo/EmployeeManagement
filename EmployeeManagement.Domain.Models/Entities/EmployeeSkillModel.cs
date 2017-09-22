using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagement.Domain.Models.Entities
{
    public class EmployeeSkillModel
    {
        public int Id { get; set; }
        public int EmployeeId { get; set; }
        public int SkillId { get; set; }
        public int Rank { get; set; }

        public EmployeeModel Employee { get; set; }
        public SkillModel Skill { get; set; }
    }
}