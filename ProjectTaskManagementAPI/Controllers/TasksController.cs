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
    public class TasksController : ControllerBase
    {
        private readonly ITaskService _service;

        public TasksController(ITaskService service)
        {
            _service = service;
        }

        private int UserId()
        {
            return int.Parse(User.FindFirst(ClaimTypes.NameIdentifier)!.Value);
        }

        [HttpPost("CreateTask")]
        public async Task<IActionResult> CreateTask(CreateTaskDto dto)
        {
            return Ok(await _service.Create(dto, UserId()));
        }

        [HttpGet("GetTaskByProject/{projectId}")]
        public async Task<IActionResult> GetTaskByProject(int projectId)
        {
            return Ok(await _service.GetByProject(projectId, UserId()));
        }

        [HttpPut("UpdateTaskStatus/{taskId}")]
        public async Task<IActionResult> UpdateTaskStatus(int taskId, UpdateTaskStatusDto dto)
        {
            return Ok(await _service.UpdateStatus(taskId, dto, UserId()));
        }

        [HttpDelete("Deletetask/{taskId}")]
        public async Task<IActionResult> Deletetask(int taskId)
        {
            return Ok(await _service.Delete(taskId, UserId()));
        }
    }
}
