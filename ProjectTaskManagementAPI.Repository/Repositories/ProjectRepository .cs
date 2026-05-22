using ProjectTaskManagementAPI.Core.Entities;
using ProjectTaskManagementAPI.Core.Interfaces;

namespace ProjectTaskManagementAPI.Repository.Repositories
{
    public class ProjectRepository : IProjectRepository
    {
        private readonly IUnitOfWork _unitOfWork;

        public ProjectRepository(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<List<Projects>> GetAllAsync()
        {
            return await _unitOfWork.Repository<Projects>().GetAllAsync();
        }

        public async Task AddAsync(Projects project)
        {
            await _unitOfWork.Repository<Projects>().AddAsync(project);
            await _unitOfWork.CompleteAsync();
        }

        public async Task<Projects?> GetByIdAsync(int id)
        {
            return await _unitOfWork.Repository<Projects>().FindAsync(x => x.Id == id);
        }
        public async Task UpdateAsync(Projects project)
        {
            _unitOfWork.Repository<Projects>().Update(project);
            await _unitOfWork.CompleteAsync();
        }
        public async Task DeleteAsync(Projects project)
        {
            _unitOfWork.Repository<Projects>().Delete(project);
            await _unitOfWork.CompleteAsync();
        }
    }
}
