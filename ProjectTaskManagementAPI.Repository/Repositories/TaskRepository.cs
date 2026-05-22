using ProjectTaskManagementAPI.Core.Entities;
using ProjectTaskManagementAPI.Core.Interfaces;

namespace ProjectTaskManagementAPI.Repository.Repositories
{
    public class TaskRepository : ITaskRepository
    {
        private readonly IUnitOfWork _unitOfWork;

        public TaskRepository(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<List<Tasks>?> GetByProjectIdAsync(int projectId)
        {
            return await _unitOfWork.Repository<Tasks>().FindAllAsync(x => x.ProjectId == projectId);
        }
        public async Task<Tasks?> GetByIdAsync(int id)
        {
            return await _unitOfWork.Repository<Tasks>().FindAsync(x => x.Id == id);
        }

        public async Task AddAsync(Tasks task)
        {
            await _unitOfWork.Repository<Tasks>().AddAsync(task);
            await _unitOfWork.CompleteAsync();
        }

        public async Task UpdateAsync(Tasks task)
        {
            _unitOfWork.Repository<Tasks>().Update(task);
            await _unitOfWork.CompleteAsync();
        }
        public async Task DeleteAsync(Tasks task)
        {
            _unitOfWork.Repository<Tasks>().Delete(task);
            await _unitOfWork.CompleteAsync();
        }
    }
}
