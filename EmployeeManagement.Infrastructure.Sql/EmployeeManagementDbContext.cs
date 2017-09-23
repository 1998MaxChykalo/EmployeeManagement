using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace EmployeeManagement.Infrastructure.Sql
{
    public class EmployeeManagementDbContext : DbContext
    {
        private IConfigurationRoot _configuration;

        public EmployeeManagementDbContext(IConfigurationRoot configuration, DbContextOptions options)
            :base(options)
        {
            _configuration = configuration;
        }
        public virtual DbSet<EmployeeProject> EmployeeProject { get; set; }
        public virtual DbSet<EmployeeSkill> EmployeeSkill { get; set; }
        public virtual DbSet<Employee> Employee { get; set; }
        public virtual DbSet<ProjectSkill> ProjectSkill { get; set; }
        public virtual DbSet<Project> Project { get; set; }
        public virtual DbSet<Skill> Skill { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer(_configuration["ConnectionStrings:EmployeeManagementSqlServerConnectionString"],
                                            b => b.MigrationsAssembly("EmpMan"));
        }
    }
}