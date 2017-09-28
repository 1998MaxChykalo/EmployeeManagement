using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace EmpMan.Migrations
{
    public partial class CorrectBooleanProperties : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Status",
                table: "Project");

            migrationBuilder.AddColumn<bool>(
                name: "IsInDevelopment",
                table: "Project",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsInDevelopment",
                table: "Project");

            migrationBuilder.AddColumn<bool>(
                name: "Status",
                table: "Project",
                nullable: false,
                defaultValue: false);
        }
    }
}
