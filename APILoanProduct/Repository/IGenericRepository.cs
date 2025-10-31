using APILoanProduct.Data;
using APILoanProduct.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace APILoanProduct.Repository
{
    public class GenericRepository<T, K> : IGenericRepository<T, K> where T : class
    {
        protected readonly Context _context;
        protected readonly DbSet<T> _dbSet;

        public GenericRepository(Context context)
        {
            _context = context;
            _dbSet = _context.Set<T>();
        }

        public virtual async Task<T> AddAsync(T entity)
        {
            await _dbSet.AddAsync(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public virtual async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _dbSet.ToListAsync();
        }

        public virtual async Task<T?> GetByIdAsync(K id)
        {
            return await _dbSet.FindAsync(id);
        }

        public virtual async Task<T> UpdateAsync(K id, T entity)
        {
            var existing = await _dbSet.FindAsync(id);
            if (existing == null)
                throw new Exception($"{typeof(T).Name} not found.");

            _context.Entry(existing).CurrentValues.SetValues(entity);
            await _context.SaveChangesAsync();
            return existing;
        }

        public virtual async Task<bool> DeleteAsync(K id)
        {
            var existing = await _dbSet.FindAsync(id);
            if (existing == null)
                return false;

            _dbSet.Remove(existing);
            await _context.SaveChangesAsync();
            return true;
        }

        public virtual async Task<IEnumerable<T>> SearchAsync(string? keyword)
        {
            throw new NotImplementedException("Search not implemented for this entity.");
        }

        public virtual async Task<IEnumerable<T>> FilterAsync(Expression<Func<T, bool>>? predicate)
        {
            if (predicate == null)
                return await GetAllAsync();

            return await _dbSet.Where(predicate).ToListAsync();
        }
    }
}
