using System;
using EmployeeManagement.Domain.Models.Entities;
using EmployeeManagement.Domain.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace EmployeeManagement.Web.Api
{
    [Route("api/skills")]
    public class SkillController : Controller
    {
        ISkillService _skillService;
        ILogger _logger;

        public SkillController(ISkillService skillService, ILoggerFactory loggerFactory)
        {
            _skillService = skillService;
            _logger = loggerFactory.CreateLogger(nameof(SkillController));
        }

        //GET api/skills
        [HttpGet]
        public IActionResult Skills()
        {
            try
            {
                var skills = _skillService.GetAllSkills();
                return Ok(skills);
            }
            catch (Exception exp)
            {
                _logger.LogError(exp.Message);
                return BadRequest(new { message = "Failed to load skills"});
            }
        }

        //POST api/skills
        [HttpPost]
        public IActionResult Skills(SkillModel skillModel)
        {
            try
            {
               _skillService.CreateSkill(skillModel);
                return Ok(new {message = "Success"});
            }
            catch(Exception exp)
            {
                _logger.LogError(exp.Message);
                return BadRequest(new { message = "Failed to create skill" });
            }
        }

        //GET api/skills/5
        [HttpGet("{id}", Name = "GetSkill")]
        public IActionResult Skills(int id)
        {
            try
            {
                var skill = _skillService.GetSkillById(id);
                return Ok(skill);
            }
            catch (System.Exception exp)
            {
                _logger.LogError(exp.Message);
                return BadRequest(new { message = "Fail to load skill" });
            }
        }

        //PUT api/skills/5
        [HttpPut("{id}")]
        public IActionResult UpdateSkill(int id,[FromBody]SkillModel skill)
        {
            try
            {
                _skillService.UpdateSkill(skill);
                return Ok(new {message = "Success"});
            }
            catch (System.Exception exp)
            {
                _logger.LogError(exp.Message);
                return BadRequest( new { message = "Fail to update skill"});
            }
        }

        //DELETE api/skills/5
        [HttpDelete("{id}")]
        public IActionResult DeleteSkill(int id)
        {
            try
            {
                _skillService.DeleteSkill(id);
                return Ok(new {message = "Success Delete"});
            }
            catch (System.Exception exp)
            {
                _logger.LogError(exp.Message);
                return BadRequest(new { message = "Fail to delete skill" });
            }
        }
        
    }
}