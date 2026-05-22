using System.Linq.Expressions;

namespace ProjectTaskManagementAPI.Core.Interfaces
{
    public interface IGenericRepository<T> where T : class
    {
        Task<List<T>> GetAllAsync();

        Task<T> FindAsync(Expression<Func<T, bool>> criteria, string[] includes = null);
        Task<List<T>> FindAllAsync(Expression<Func<T, bool>> criteria, string[] includes = null);
        Task AddAsync(T entity);

        void Update(T entity);

        void Delete(T entity);
    }
}
