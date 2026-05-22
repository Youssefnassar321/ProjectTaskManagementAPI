using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProjectTaskManagementAPI.Core.Dtos;
using ProjectTaskManagementAPI.Core.InterfacesService;
using System.Security.Claims;

namespace ProjectTaskManagementAPI.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class ProjectsController : ControllerBase
    {
        private readonly IProjectService _projectservice;

        public ProjectsController(IProjectService projectservice)
        {
            _projectservice = projectservice;
        }

        private int GetUserId()
        {
            return int.Parse(User.FindFirst(ClaimTypes.NameIdentifier)?.Value);
        }

        [HttpPost("CreateProject")]
        public async Task<IActionResult> CreateProject(CreateProjectDto dto)
        {
            var id = await _projectservice.CreateProject(dto, GetUserId());
            return Ok(id);
        }

        [HttpGet("GetAllProject")]
        public async Task<IActionResult> GetAllProject()
        {
            return Ok(await _projectservice.GetAllProjects(GetUserId()));
        }

        [HttpGet("GetProjectById/{id}")]
        public async Task<IActionResult> GetProjectById(int id)
        {
            var result = await _projectservice.GetById(id, GetUserId());

            if (result == null)
                return NotFound();

            return Ok(result);
        }

        [HttpPut("UpdateProject/{id}")]
        public async Task<IActionResult> UpdateProject(int id, UpdateProjectDto dto)
        {
            var result = await _projectservice.UpdateProject(id, dto, GetUserId());

            if (!result)
                return NotFound();

            return Ok();
        }

        [HttpDelete("DeleteProject/{id}")]
        public async Task<IActionResult> DeleteProject(int id)
        {
            var result = await _projectservice.DeleteProject(id, GetUserId());

            if (!result)
                return NotFound();

            return Ok();
        }
    }
}
