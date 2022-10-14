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
            _query = context.Set<T>();
            _context = context;
        }

        public DbContext getContext()
        {
            return _context;
        }

        public async Task<T> Insert(T entity, CancellationToken cancellationToken = default)
        {
            await _query.AddAsync(entity, cancellationToken);
            return entity;
        }
    }
}
