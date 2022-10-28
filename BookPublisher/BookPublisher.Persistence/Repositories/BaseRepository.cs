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

        public T Get(int id)
        {
            return _query.Find(id);
        }

        public async Task<T> GetAsync(int id)
        {
            return await _query.FindAsync(id);
        }

        public async Task<IEnumerable<T>> ListAsync()
        {
            return await _query.ToListAsync();
        }

        public async Task<T> InsertAsync(T entity)
        {
            await _query.AddAsync(entity);
            await _context.SaveChangesAsync();

            return entity;
        }

        public async Task<T> UpdateAsync(T entity)
        {
            _query.Update(entity);
            await _context.SaveChangesAsync();

            return entity;
        }

        public async Task<T> DeleteAsync(int id)
        {
            var entity = Get(id);

            _query.Remove(entity);
            await _context.SaveChangesAsync();

            return entity;
        }

        public async void Commit()
        {
            await _context.SaveChangesAsync();
        }
    }
}
