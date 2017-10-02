﻿// <auto-generated />
using EmployeeManagement.Infrastructure.Sql;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using System;

namespace EmpMan.Migrations
{
    [DbContext(typeof(EmployeeManagementDbContext))]
    [Migration("20170928141109_AddIdentity")]
    partial class AddIdentity
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.0.0-rtm-26452")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("EmployeeManagement.Infrastructure.Sql.Employee", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<bool>("IsAvailable");

                    b.Property<string>("Name");

                    b.Property<byte[]>("Photo");

                    b.Property<int>("Rank");

                    b.HasKey("Id");

                    b.ToTable("Employee");
                });

            modelBuilder.Entity("EmployeeManagement.Infrastructure.Sql.EmployeeProject", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("EmployeeId");

                    b.Property<int>("ProjectId");

                    b.HasKey("Id");

                    b.HasIndex("EmployeeId");

                    b.HasIndex("ProjectId");

                    b.ToTable("EmployeeProject");
                });

            modelBuilder.Entity("EmployeeManagement.Infrastructure.Sql.EmployeeSkill", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("EmployeeId");

                    b.Property<int>("Rank");

                    b.Property<int>("SkillId");

                    b.HasKey("Id");

                    b.HasIndex("EmployeeId");

                    b.HasIndex("SkillId");

                    b.ToTable("EmployeeSkill");
                });

            modelBuilder.Entity("EmployeeManagement.Infrastructure.Sql.Project", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Description");

                    b.Property<bool>("IsInDevelopment");

                    b.Property<string>("Name");

                    b.Property<DateTime>("StartDateUtc");

                    b.HasKey("Id");

                    b.ToTable("Project");
                });

            modelBuilder.Entity("EmployeeManagement.Infrastructure.Sql.ProjectSkill", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("ProjectId");

                    b.Property<int>("Rank");

                    b.Property<int>("SkillId");

                    b.HasKey("Id");

                    b.HasIndex("ProjectId");

                    b.HasIndex("SkillId");

                    b.ToTable("ProjectSkill");
                });

            modelBuilder.Entity("EmployeeManagement.Infrastructure.Sql.Skill", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("Skill");
                });

            modelBuilder.Entity("EmployeeManagement.Infrastructure.Sql.EmployeeProject", b =>
                {
                    b.HasOne("EmployeeManagement.Infrastructure.Sql.Employee", "Employee")
                        .WithMany("EmployeeProjects")
                        .HasForeignKey("EmployeeId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("EmployeeManagement.Infrastructure.Sql.Project", "Project")
                        .WithMany("EmployeeProjects")
                        .HasForeignKey("ProjectId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("EmployeeManagement.Infrastructure.Sql.EmployeeSkill", b =>
                {
                    b.HasOne("EmployeeManagement.Infrastructure.Sql.Employee", "Employee")
                        .WithMany("EmployeeSkills")
                        .HasForeignKey("EmployeeId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("EmployeeManagement.Infrastructure.Sql.Skill", "Skill")
                        .WithMany("EmployeeSkills")
                        .HasForeignKey("SkillId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("EmployeeManagement.Infrastructure.Sql.ProjectSkill", b =>
                {
                    b.HasOne("EmployeeManagement.Infrastructure.Sql.Project", "Project")
                        .WithMany("ProjectSkills")
                        .HasForeignKey("ProjectId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("EmployeeManagement.Infrastructure.Sql.Skill", "Skill")
                        .WithMany("ProjectSkills")
                        .HasForeignKey("SkillId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
