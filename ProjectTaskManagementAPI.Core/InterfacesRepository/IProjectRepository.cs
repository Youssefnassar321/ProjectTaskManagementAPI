using ProjectTaskManagementAPI.Core.Entities;

namespace ProjectTaskManagementAPI.Core.Interfaces
{
    public interface IProjectRepository
    {
        Task<List<Projects>> GetAllAsync();
        Task AddAsync(Projects project);
        Task<Projects?> GetByIdAsync(int id);
        Task UpdateAsync(Projects project);
        Task DeleteAsync(Projects project);
    }
}
