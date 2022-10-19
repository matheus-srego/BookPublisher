using BookPublisher.Domain.Interfaces.Repositories;
using BookPublisher.Domain.Interfaces.Services;
using BookPublisher.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookPublisher.Service.Services
{
    public class BaseService<T> : IBaseService<T> where T : BaseEntity
    {
        private readonly IBaseRepository<T> _baseRepository;

        public BaseService(IBaseRepository<T> baseRepository)
        {
            _baseRepository = baseRepository;
        }

        public async Task<T> GetById(long id)
        {
            var entity = await _baseRepository.GetById(id);
            return entity;
        }

        public async Task<IEnumerable<T>> GetAll()
        {
            return await _baseRepository.GetAll();
        }

        public async Task<T> Insert(T entity)
        {
            await _baseRepository.Insert(entity);
            return entity;
        }

        public async Task<T> Delete(long id)
        {
            var entity = await _baseRepository.Delete(id);
            return entity;
        }
    }
}
