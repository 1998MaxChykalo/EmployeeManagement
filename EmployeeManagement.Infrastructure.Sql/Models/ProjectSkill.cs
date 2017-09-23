namespace EmployeeManagement.Infrastructure.Sql
{
    public class ProjectSkill : IEntityBase
    {
        public int Id { get; set; }
        public int ProjectId { get; set; }
        public int SkillId { get; set; }
        public int Rank { get; set; }

        public virtual Project Project { get; set; }
        public virtual Skill Skill { get; set; }
    }
}