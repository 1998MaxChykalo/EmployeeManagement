using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagement.Domain.Models.Entities
{
    public class EmployeeProjectModel
    {
        public int Id { get; set; }
        public int ProjectId { get; set; }
        public int EmployeeId { get; set; }

        public EmployeeModel Employee { get; set; }
        public ProjectModel Project { get; set; }
    }
}