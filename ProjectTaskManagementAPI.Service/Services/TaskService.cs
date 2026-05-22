using ProjectTaskManagementAPI.Core.Dtos;
using ProjectTaskManagementAPI.Core.Entities;
using ProjectTaskManagementAPI.Core.Interfaces;
using ProjectTaskManagementAPI.Core.InterfacesService;

namespace ProjectTaskManagementAPI.Service.Services
{
    public class TaskService : ITaskService
    {
        private readonly ITaskRepository _taskRepository;
        private readonly IProjectRepository _projectRepository;

        public TaskService(ITaskRepository taskRepository, IProjectRepository projectRepository)
        {
            _taskRepository = taskRepository;
            _projectRepository = projectRepository;
        }

        public async Task<int> Create(CreateTaskDto dto, int userId)
        {
            var project = await _projectRepository.GetByIdAsync(dto.ProjectId);

            if (project == null)
                throw new Exception("Project not found");

            var task = new Tasks
            {
                Title = dto.Title,
                Description = dto.Description,
                DueDate = dto.DueDate,
                Priority = dto.Priority,
                Status = "Pending",
                ProjectId = dto.ProjectId
            };

            await _taskRepository.AddAsync(task);

            return task.Id;
        }

        public async Task<List<TaskDto>> GetByProject(int projectId, int userId)
        {
            var project = await _projectRepository.GetByIdAsync(projectId);

            if (project == null)
                return new List<TaskDto>();

            var tasks = await _taskRepository.GetByProjectIdAsync(projectId);

            return tasks
                .Select(t => new TaskDto
                {
                    Id = t.Id,
                    Title = t.Title,
                    Description = t.Description,
                    Status = t.Status,
                    DueDate = t.DueDate,
                    Priority = t.Priority,
                    ProjectId = t.ProjectId
                })
                .ToList();
        }

        public async Task<bool> UpdateStatus(int taskId, UpdateTaskStatusDto dto, int userId)
        {
            var task = await _taskRepository.GetByIdAsync(taskId);

            if (task == null)
                return false;

            task.Status = dto.Status;

            await _taskRepository.UpdateAsync(task);

            return true;
        }

        public async Task<bool> Delete(int taskId, int userId)
        {
            var task = await _taskRepository.GetByIdAsync(taskId);

            if (task == null)
                return false;

            await _taskRepository.DeleteAsync(task);

            return true;
        }
    }
}
