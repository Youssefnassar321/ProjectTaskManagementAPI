using ProjectTaskManagementAPI.Core.Entities;

namespace ProjectTaskManagementAPI.Core.InterfacesRepository
{
    public interface IUserRepository
    {
        Task<Users?> GetByUserNameAsync(string username);
        Task AddAsync(Users user);
    }
}
