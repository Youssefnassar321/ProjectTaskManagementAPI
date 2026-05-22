using ProjectTaskManagementAPI.Core.Dtos;

namespace ProjectTaskManagementAPI.Core.InterfacesService
{
    public interface ITaskService
    {
        Task<int> Create(CreateTaskDto dto, int userId);

        Task<List<TaskDto>> GetByProject(int projectId, int userId);

        Task<bool> UpdateStatus(int taskId, UpdateTaskStatusDto dto, int userId);

        Task<bool> Delete(int taskId, int userId);
    }
}
