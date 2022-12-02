using BookPublisher.Domain.Interfaces.Repositories;
using BookPublisher.Domain.Models;
using BookPublisher.Persistence.Context;
using Microsoft.EntityFrameworkCore;

namespace BookPublisher.Persistence.Repositories
{
    public class BaseRepository<T> : IBaseRepository<T> where T : BaseEntity
    {
        protected readonly DbSet<T> _query;
        protected readonly BookPublisherContext _context;

        public BaseRepository(BookPublisherContext context)
        {
            _context = context;
            _query = _context.Set<T>();
        }

        public virtual async Task<T?> GetAsync(int? id) => await _query.FindAsync(id);

        public virtual async Task<IEnumerable<T?>> ListAsync() => await _query.ToListAsync();

        public virtual async Task<T?> InsertAsync(T? entity)
        {
            if(entity != null)
                await _query.AddAsync(entity);
                await _context.SaveChangesAsync();
            
            return entity;
        }

        public virtual async Task<T?> UpdateAsync(T? entity)
        {
            if(entity != null)
                _query.Update(entity);
                await _context.SaveChangesAsync();
            
            return entity;
        }

        public virtual async Task<T?> DeleteAsync(T? entity)
        {
            if(entity != null)
                _query.Remove(entity);
                await _context.SaveChangesAsync();
            
            return entity;
        }
    }
}
