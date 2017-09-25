namespace EmployeeManagement.Domain.Models
{
    public interface IEntityBase
    {
        int Id { get; set; }
    }
    public class EntityBase : IEntityBase
    {
        public int Id { get; set; }
    }
}