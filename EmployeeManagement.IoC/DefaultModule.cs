
using Autofac;
using EmployeeManagement.Infrastructure.Sql;
using EmployeeManagement.Domain.Services.Employee;
using EmployeeManagement.Domain.Services.Interfaces;
using EmployeeManagement.Domain.Services.Project;
using EmployeeManagement.Domain.Services.Skill;
using EmployeeManagement.Infrastructure.UnitOfWork;

namespace EmployeeManagement.IoC
{
    public class DefaultModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            //builder.RegisterType<ContainerManager>().As<CompanySkillsDataBaseContext>();
            
            // Register infrastructure dependencies.
            builder.RegisterType<HttpUnitOfWork>().As<IUnitOfWork>();

            // Register domain services.
            builder.RegisterType<EmployeeService>().As<IEmployeeService>();
            builder.RegisterType<ProjectService>().As<IProjectService>();
            builder.RegisterType<SkillService>().As<ISkillService>();
            // builder.RegisterType<ProjectSkillService>().As<IProjectSkillService>();
            // builder.RegisterType<EmployeeProjectService>().As<IEmployeeProjectService>();
            // builder.RegisterType<EmployeeSkillService>().As<IEmployeeSkillService>();

        }
    }
}