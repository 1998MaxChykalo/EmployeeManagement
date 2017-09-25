using System.Collections.Generic;

namespace EmployeeManagement.Domain.Models.Entities
{
    public class EmployeeModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        // public string UserId { get; set; }
        public byte[] Photo { get; set; }
        public bool IsAvailable { get; set; }
        public int Rank { get; set; }

        public ICollection<EmployeeProjectModel> EmployeeProjects { get; set; }
        public ICollection<EmployeeSkillModel> EmployeeSkills { get; set; }
    }
}