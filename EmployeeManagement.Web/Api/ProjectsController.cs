
using System;
using EmployeeManagement.Domain.Models.Entities;
using EmployeeManagement.Domain.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace EmployeeManagement.Web.Api
{
    [Route("api/projects")]
    public class ProjectController : Controller
    {
        IProjectService _projectService;
        ILogger _logger;

        public ProjectController(IProjectService projectService, ILoggerFactory loggerFactory)
        {
            _projectService = projectService;
            _logger = loggerFactory.CreateLogger(nameof(ProjectController));
        }

        //GET api/projects
        [HttpGet]
        public IActionResult Projects()
        {
            try
            {
                var projects = _projectService.GetAllProjects();
                return Ok(projects);
            }
            catch (Exception exp)
            {
                _logger.LogError(exp.Message);
                return BadRequest(new { message = "Failed to load projects"});
            }
        }

        //POST api/projects
        [HttpPost]
        public IActionResult Projects(ProjectModel projectModel)
        {
            try
            {
               _projectService.CreateProject(projectModel);
                return Ok(new {message = "Success"});
            }
            catch(Exception exp)
            {
                _logger.LogError(exp.Message);
                return BadRequest(new { message = "Failed to create project" });
            }
        }

        //GET api/projects/5
        [HttpGet("{id}", Name = "GetProject")]
        public IActionResult Projects(int id)
        {
            try
            {
                var project = _projectService.GetProjectById(id);
                return Ok(project);
            }
            catch (System.Exception exp)
            {
                _logger.LogError(exp.Message);
                return BadRequest(new { message = "Fail to load project" });
            }
        }

        //PUT api/projects/5
        [HttpPut("{id}")]
        public IActionResult UpdateProject(int id,[FromBody]ProjectModel project)
        {
            try
            {
                _projectService.UpdateProject(project);
                return Ok(new {message = "Success"});
            }
            catch (System.Exception exp)
            {
                _logger.LogError(exp.Message);
                return BadRequest( new { message = "Fail to update project"});
            }
        }

        //DELETE api/projects/5
        [HttpDelete("{id}")]
        public IActionResult DeleteProject(int id)
        {
            try
            {
                _projectService.DeleteProject(id);
                return Ok(new {message = "Success Delete"});
            }
            catch (System.Exception exp)
            {
                _logger.LogError(exp.Message);
                return BadRequest(new { message = "Fail to delete project" });
            }
        }
    }
}