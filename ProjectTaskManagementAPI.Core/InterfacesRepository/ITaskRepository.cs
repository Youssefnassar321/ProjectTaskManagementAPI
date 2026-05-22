using ProjectTaskManagementAPI.Core.Entities;

namespace ProjectTaskManagementAPI.Core.Interfaces
{
    public interface ITaskRepository
    {
        Task<List<Tasks>?> GetByProjectIdAsync(int projectId);
        Task<Tasks?> GetByIdAsync(int id);
        Task AddAsync(Tasks task);
        Task UpdateAsync(Tasks task);
        Task DeleteAsync(Tasks task);
    }
}
