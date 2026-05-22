using Microsoft.EntityFrameworkCore;
using ProjectTaskManagementAPI.Core.Interfaces;
using ProjectTaskManagementAPI.Data;
using System.Linq.Expressions;

namespace ProjectTaskManagementAPI.Repository.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly ApplicationDbContext _context;
        private readonly DbSet<T> _dbSet;

        public GenericRepository(ApplicationDbContext context)
        {
            _context = context;
            _dbSet = _context.Set<T>();
        }

        public async Task<List<T>> GetAllAsync()
            => await _dbSet.ToListAsync();

        public async Task<T> FindAsync(Expression<Func<T, bool>> criteria, string[] includes = null)
        {
            IQueryable<T> query = _context.Set<T>().AsNoTracking();
            if (includes != null)
            {
                foreach (var item in includes)
                {
                    if (query.Include(item) != null)
                        query = query.Include(item);
                }
            }
            return await query.FirstOrDefaultAsync(criteria);
        }

        public async Task<List<T>> FindAllAsync(Expression<Func<T, bool>> criteria, string[] includes = null)
        {
            IQueryable<T> query = _context.Set<T>().AsNoTracking();
            if (includes != null)
            {
                foreach (var item in includes)
                {
                    if (query.Include(item) != null)
                        query = query.Include(item);
                }
            }
            return await query.Where(criteria).ToListAsync();
        }
        public async Task AddAsync(T entity)
            => await _dbSet.AddAsync(entity);

        public void Update(T entity)
            => _dbSet.Update(entity);

        public void Delete(T entity)
            => _dbSet.Remove(entity);
    }
}
