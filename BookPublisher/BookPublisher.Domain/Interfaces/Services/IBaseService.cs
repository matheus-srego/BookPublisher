using BookPublisher.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookPublisher.Domain.Interfaces.Services
{
    public interface IBaseService<T> where T : BaseEntity
    {
        Task<T> GetById(long id);
        Task<T> Insert(T entity);
        Task<T> Update(T entity);
        Task<IEnumerable<T>> GetAll();
        Task<T> Delete(long ind);
    }
}
