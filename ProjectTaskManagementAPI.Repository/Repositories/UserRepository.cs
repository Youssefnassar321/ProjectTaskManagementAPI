using ProjectTaskManagementAPI.Core.Entities;
using ProjectTaskManagementAPI.Core.Interfaces;
using ProjectTaskManagementAPI.Core.InterfacesRepository;

namespace ProjectTaskManagementAPI.Repository.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly IUnitOfWork _unitOfWork;
        public UserRepository(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<Users?> GetByUserNameAsync(string username)
        {
            return await _unitOfWork.Repository<Users>().FindAsync(x => x.UserName == username);
        }
        public async Task AddAsync(Users user)
        {
            await _unitOfWork.Repository<Users>().AddAsync(user);
            await _unitOfWork.CompleteAsync();
        }
    }
}
