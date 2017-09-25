using System;
using System.IO;
using AutoMapper;
using EmployeeManagement.Domain.Models.Entities;
using Microsoft.AspNetCore.Http;

namespace EmployeeManagement.Infrastructure.Sql
{
    public class AutoMapperConfig
    {
        private static bool _isConfigured;
        private static readonly object Lock = new object();
        public static void Configure()
        {
            lock (Lock)
            {
                if (!_isConfigured)
                {
                    Mapper.Initialize(cfg =>
                    {
                        cfg.CreateMap<EmployeeProjectModel, EmployeeProject>().PreserveReferences();
                        cfg.CreateMap<EmployeeProject, EmployeeProjectModel>().PreserveReferences();
                        cfg.CreateMap<EmployeeModel, Employee>().PreserveReferences();
                        cfg.CreateMap<Employee, EmployeeModel>().PreserveReferences();
                        cfg.CreateMap<EmployeeSkillModel, EmployeeSkill>().PreserveReferences();
                        cfg.CreateMap<EmployeeSkill, EmployeeSkillModel>().PreserveReferences();
                        cfg.CreateMap<ProjectModel, Project>().PreserveReferences();
                        cfg.CreateMap<Project, ProjectModel>().PreserveReferences();
                        cfg.CreateMap<ProjectSkillModel, ProjectSkill>().PreserveReferences();
                        cfg.CreateMap<ProjectSkill, ProjectSkillModel>().PreserveReferences();
                        cfg.CreateMap<SkillModel, Skill>().PreserveReferences();
                        cfg.CreateMap<Skill, SkillModel>().PreserveReferences();
                    });

                    _isConfigured = true;
                }
            }
        }
    }
}