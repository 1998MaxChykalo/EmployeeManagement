using System.Threading;
using System.Threading.Tasks;
using EmployeeManagement.Infrastructure.Sql.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace EmployeeManagement.Infrastructure.Sql
{
    public class EmployeeManagementDbContext : IdentityDbContext<ApplicationUser, ApplicationRole, string>
    {
        private IConfigurationRoot _configuration;

        public EmployeeManagementDbContext(IConfigurationRoot configuration, DbContextOptions options)
            :base(options)
        {
            this._configuration = configuration;
        }
        public string CurrentUserId { get; set; }
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
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<ApplicationUser>().HasMany(u => u.Claims).WithOne().HasForeignKey(c => c.UserId).IsRequired().OnDelete(DeleteBehavior.Cascade);
            builder.Entity<ApplicationUser>().HasMany(u => u.Roles).WithOne().HasForeignKey(r => r.UserId).IsRequired().OnDelete(DeleteBehavior.Cascade);
            
            builder.Entity<ApplicationRole>().HasMany(r => r.Claims).WithOne().HasForeignKey(c => c.RoleId).IsRequired().OnDelete(DeleteBehavior.Cascade);
            builder.Entity<ApplicationRole>().HasMany(r => r.Users).WithOne().HasForeignKey(r => r.RoleId).IsRequired().OnDelete(DeleteBehavior.Cascade);

        }




        public override int SaveChanges()
        {
            return base.SaveChanges();
        }


        public override int SaveChanges(bool acceptAllChangesOnSuccess)
        {
            return base.SaveChanges(acceptAllChangesOnSuccess);
        }


        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            return base.SaveChangesAsync(cancellationToken);
        }


        public override Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = default(CancellationToken))
        {
            return base.SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken);
        }

    }
}