using BookPublisher.Domain.Interfaces.Repositories;
using BookPublisher.Domain.Models;
using BookPublisher.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookPublisher.Persistence.Repositories
{
    public class BaseRepository<T> : IBaseRepository<T> where T : BaseEntity
    {
        protected readonly DbSet<T> _query;
        public BookPublisherContext _context;

        public BaseRepository(BookPublisherContext context)
        {
            _context = context;
            _query = _context.Set<T>();
        }

        public async Task<T> GetById(long id)
        {
            var entity = await _query.FindAsync(id);
            return entity;
        }

        public async Task<IEnumerable<T>> GetAll()
        {
            var authors = await _query.ToListAsync();
            return authors;
        }

        public DbContext getContext()
        {
            return _context;
        }

        public async Task<T> Insert(T entity)
        {
            await _query.AddAsync(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task<T> Delete(long id)
        {
            var entity = _query.Find(id);

            _query.Remove(entity);
            await _context.SaveChangesAsync();

            return entity;
        }
    }
}
