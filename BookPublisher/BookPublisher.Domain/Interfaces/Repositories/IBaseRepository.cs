using BookPublisher.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookPublisher.Domain.Interfaces.Repositories
{
    public interface IBaseRepository<T> where T : BaseEntity
    {
        Task<T> GetById(long id);
        DbContext getContext();
        Task<T> Insert(T entity);
        Task<IEnumerable<T>> GetAll();
        Task<T> Delete(long id);
    }
}
